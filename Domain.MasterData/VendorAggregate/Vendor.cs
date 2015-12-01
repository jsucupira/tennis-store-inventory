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
            IsActive = true;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }

        public Vendor(string id, string name, string accountNumber)
        {
            Id = id;
            AccountNumber = accountNumber;
            Name = name;
        }

        public string AccountNumber { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsLocked { get; private set; }
        public string LastModifiedBy { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public string LockedBy { get; private set; }
        public string Name { get; private set; }
        public bool PreferredVendorStatus { get; set; }
        public string PurchasingWebServiceUrl { get; set; }
        public IReadOnlyList<VendorAddress> VendorAddresses { get; private set; }
        public IReadOnlyList<VendorContact> VendorContacts { get; private set; }
        public IReadOnlyList<VendorProduct> VendorProducts { get; private set; }

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
            return new VendorValidator();
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

        internal void SetCollections(IReadOnlyList<VendorAddress> vendorAddresses, IReadOnlyList<VendorContact> vendorContacts, IReadOnlyList<VendorProduct> vendorProducts)
        {
            VendorAddresses = vendorAddresses;
            VendorContacts = vendorContacts;
            VendorProducts = vendorProducts;
        }

        public void UnlockEntity()
        {
            IsLocked = false;
        }
    }
}