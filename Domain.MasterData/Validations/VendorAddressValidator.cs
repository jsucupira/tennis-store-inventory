using Domain.MasterData.VendorAggregate;
using FluentValidation;

namespace Domain.MasterData.Validations
{
    public class VendorAddressValidator : AbstractValidator<VendorAddress>
    {
        public VendorAddressValidator()
        {
            RuleFor(t => t.VendorId).NotEmpty();
            RuleFor(t => t.AddressLine1).NotEmpty();
            RuleFor(t => t.City).NotEmpty();
            RuleFor(t => t.Region).NotEmpty();
            RuleFor(t => t.PostalCode).NotEmpty();
        }
    }
}