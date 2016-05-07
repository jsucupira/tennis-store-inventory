using FluentValidation;
using System;
using System.Diagnostics.CodeAnalysis;
using Domain.MasterData.StoreAggregate;

namespace Domain.MasterData.Validations
{
    [ExcludeFromCodeCoverage]
    public class StoreAddressValidator : AbstractValidator<StoreAddress>
    {
        public StoreAddressValidator()
        {
            RuleFor(t => t.StoreId).NotEqual(Guid.Empty);
            RuleFor(t => t.AddressLine1).NotEmpty();
            RuleFor(t => t.City).NotEmpty();
            RuleFor(t => t.Region).NotEmpty();
            RuleFor(t => t.PostalCode).NotEmpty();
            RuleFor(t => t.Id).NotEmpty();
        }
    }
}