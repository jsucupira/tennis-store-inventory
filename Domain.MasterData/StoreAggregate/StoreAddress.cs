using System;
using Core.Common.Model;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.StoreAggregate
{
    public sealed class StoreAddress : Entity<int>
    {
        private StoreAddress()
        {
        }

        public StoreAddress(Guid storeId, string street1, string street2, string city, string region, string country, string postalCode, string addressType)
            : this()
        {
            AddressLine1 = street1;
            AddressLine2 = street2;
            City = city;
            Region = region;
            Country = country;
            PostalCode = postalCode;
            AddressType = addressType;
            StoreId = storeId;
        }

        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string AddressType { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public double? Latitude { get; private set; }
        public double? Longitude { get; private set; }
        public string PostalCode { get; private set; }
        public string Region { get; private set; }
        public Guid StoreId { get; private set; }

        protected override IValidator GetValidator()
        {
            return new StoreAddressValidator();
        }
    }
}