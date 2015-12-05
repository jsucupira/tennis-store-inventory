using System;
using System.Collections.Generic;
using Core.Common.Model;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.VendorAggregate
{
    public sealed class Vendor : Entity<string>
    {
        private Vendor()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public Vendor(string id, string name, string accountNumber)
        {
            Id = id;
            AccountNumber = accountNumber;
            Name = name;
        }

        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public bool PreferredVendorStatus { get; set; }
        public string PurchasingWebServiceUrl { get; set; }
        public IReadOnlyList<VendorAddress> VendorAddresses { get; private set; }
        public IReadOnlyList<VendorContact> VendorContacts { get; private set; }
        public IReadOnlyList<VendorProduct> VendorProducts { get; private set; }

        protected override IValidator GetValidator()
        {
            return new VendorValidator();
        }

        internal void SetCollections(IReadOnlyList<VendorAddress> vendorAddresses, IReadOnlyList<VendorContact> vendorContacts, IReadOnlyList<VendorProduct> vendorProducts)
        {
            VendorAddresses = vendorAddresses;
            VendorContacts = vendorContacts;
            VendorProducts = vendorProducts;
        }
    }
}