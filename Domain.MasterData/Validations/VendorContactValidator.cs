using Core.Common.Validations;
using Domain.MasterData.VendorAggregate;
using FluentValidation;

namespace Domain.MasterData.Validations
{
    public class VendorContactValidator : AbstractValidator<VendorContact>
    {
        public VendorContactValidator()
        {
            RuleFor(t => t.VendorId).NotEmpty();
            RuleFor(t => t.EmailAddress).NotEmpty();
            RuleFor(t => t.EmailAddress).Must(t => t.IsValidEmail());
        }
    }
}