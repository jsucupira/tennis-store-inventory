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

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressType { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public Guid StoreId { get; private set; }

        protected override IValidator GetValidator()
        {
            return new StoreAddressValidator();
        }
    }
}