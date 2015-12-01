using Core.Common.Model;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.VendorAggregate
{
    public sealed class VendorAddress : Entity<int>
    {
        private VendorAddress()
        {
        }

        public VendorAddress(string vendorId, string street1, string street2, string city, string region, string country, string postalCode, string addressType)
            : this()
        {
            AddressLine1 = street1;
            AddressLine2 = street2;
            City = city;
            Region = region;
            Country = country;
            PostalCode = postalCode;
            AddressType = addressType;
            VendorId = vendorId;
        }

        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string AddressType { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string PostalCode { get; private set; }
        public string Region { get; private set; }
        public string VendorId { get; private set; }
        
        protected override IValidator GetValidator()
        {
            return new VendorAddressValidator();
        }
    }
}