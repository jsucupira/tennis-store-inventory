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
            Sizes = new List<Size>();
        }

        public Product(string id, string name, string description, int categoryId, decimal standardCost) : this()
        {
            Id = id;
            Description = description;
            Name = name;
            StandardCost = standardCost;
            ProductCategoryId = categoryId;
        }

        public string Color { get; set; }
        public string Description { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public decimal? ListPrice { get; set; }
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public IReadOnlyList<Photo> ProductPhotos { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? SellStartDate { get; set; }
        public List<Size> Sizes { get; set; }
        public decimal StandardCost { get; set; }
        public double Weight { get; set; }
        public string WeightUnitMeasureCode { get; set; }


        protected override IValidator GetValidator()
        {
            return new ProductValidator();
        }
        
        internal void SetCollections(List<Photo> photos)
        {
            ProductPhotos = photos.AsReadOnly();
        }
    }
}