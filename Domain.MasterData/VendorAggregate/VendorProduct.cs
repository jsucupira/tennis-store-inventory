using System;
using Core.Common.Model;
using Domain.CrossCutting.Products;
using Domain.MasterData.ProductAggregate;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.VendorAggregate
{
    public sealed class VendorProduct : Entity<Guid>
    {
        public VendorProduct(string vendorId, string vendorProductKey, decimal standardPrice, UnitMeasure unitMeasure) 
            : this()
        {
            StandardPrice = standardPrice;
            UnitMeasure = unitMeasure.ToString();
            VendorId = vendorId;
            VendorProductKey = vendorProductKey;
        }

        private VendorProduct()
        {
            Id = Guid.NewGuid();
        }

        public decimal? LastReceiptCost { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public decimal StandardPrice { get; private set; }
        public string UnitMeasure { get; private set; }
        public string VendorId { get; private set; }
        public string VendorProductKey { get; private set; }

        protected override IValidator GetValidator()
        {
            return new VendorProductValidator();
        }
    }
}