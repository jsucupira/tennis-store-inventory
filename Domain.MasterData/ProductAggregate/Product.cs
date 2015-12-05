using System;
using System.Collections.Generic;
using Core.Common.Model;
using Domain.CrossCutting.Products;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.ProductAggregate
{
    public sealed class Product : Entity<string>
    {
        private Product()
        {
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }

        public Product(string id, string description,string name, int categoryId, UnitMeasure sizeUnitMeasureCode, decimal standardCost,
            UnitMeasure weightUnitMeasureCode) : this()
        {
            Id = id;
            Description = description;
            Name = name;
            SizeUnitMeasureCode = sizeUnitMeasureCode.ToString();
            StandardCost = standardCost;
            WeightUnitMeasureCode = weightUnitMeasureCode.ToString();
            ProductCategoryId = categoryId;
        }

        public string Color { get; set; }
        public DateTime CreatedDate { get; private set; }
        public string Description { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public bool IsActive { get; private set; }
        public bool IsLocked { get; private set; }
        public string LastModifiedBy { get; private set; }
        public DateTime LastModifiedDate { get; set; }
        public decimal? ListPrice { get; set; }
        public string LockedBy { get; set; }
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public IReadOnlyList<Photo> ProductPhotos { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? SellStartDate { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public decimal StandardCost { get; set; }
        public decimal? Weight { get; set; }
        public string WeightUnitMeasureCode { get; set; }

        public void Activate()
        {
            IsActive = true;
        }

        public void DeActivate()
        {
            IsActive = false;
        }

        protected override IValidator GetValidator()
        {
            return new ProductValidator();
        }

        public void LockEntity(string lockedBy)
        {
            IsLocked = true;
            LockedBy = lockedBy;
        }

        public void ModifiedBy(string userName)
        {
            LastModifiedBy = userName;
        }

        internal void SetCollections(List<Photo> photos)
        {
            ProductPhotos = photos.AsReadOnly();
        }

        public void UnlockEntity()
        {
            IsLocked = false;
        }
    }
}