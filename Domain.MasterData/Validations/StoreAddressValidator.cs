using FluentValidation;
using System;
using Domain.MasterData.StoreAggregate;

namespace Domain.MasterData.Validations
{
    public class StoreAddressValidator : AbstractValidator<StoreAddress>
    {
        public StoreAddressValidator()
        {
            RuleFor(t => t.StoreId).NotEqual(Guid.Empty);
            RuleFor(t => t.AddressLine1).NotEmpty();
            RuleFor(t => t.City).NotEmpty();
            RuleFor(t => t.Region).NotEmpty();
            RuleFor(t => t.PostalCode).NotEmpty();
        }
    }
}