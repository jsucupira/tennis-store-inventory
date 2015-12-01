using Core.Common.Model;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.VendorAggregate
{
    public sealed class VendorContact : Entity<int>
    {
        private VendorContact()
        {
        }

        public VendorContact(string vendorId, string contactType, string firstName, string lastName)
            : this()
        {
            ContactType = contactType;
            FirstName = firstName;
            LastName = lastName;
            VendorId = vendorId;
        }

        public string AdditionalContactInfo { get; set; }
        public string CellPhone { get; set; }
        public string ContactType { get; private set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; private set; }
        public string HomeExtension { get; set; }
        public string HomePhone { get; set; }
        public string LastName { get; private set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }

        public string VendorId { get; private set; }
        public string WorkExtension { get; set; }
        public string WorkPhone { get; set; }

        protected override IValidator GetValidator()
        {
            return new VendorContactValidator();
        }
    }
}