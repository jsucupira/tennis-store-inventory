using System;
using Core.Common.Model;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.StoreAggregate
{
    [Serializable]
    public sealed class StoreContact : Entity<int>
    {
        private StoreContact()
        {
        }

        public StoreContact(Guid storeId, string contactType, string firstName, string lastName) : this()
        {
            ContactType = contactType;
            FirstName = firstName;
            LastName = lastName;
            StoreId = storeId;
            StoreId = storeId;
        }


        public string AdditionalContactInfo { get; set; }
        public string CellPhone { get; set; }
        public string ContactType { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string HomeExtension { get; set; }
        public string HomePhone { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Guid StoreId { get; private set; }
        public string Suffix { get; set; }
        public string Title { get; set; }

        protected override IValidator GetValidator()
        {
            return new StoreContactValidator();
        }
    }
}