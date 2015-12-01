using Domain.MasterData.VendorAggregate;
using FluentValidation;

namespace Domain.MasterData.Validations
{
    public class VendorProductValidator : AbstractValidator<VendorProduct>
    {
        public VendorProductValidator()
        {
            RuleFor(t => t.StandardPrice).GreaterThan(0);
            RuleFor(t => t.VendorId).NotEmpty();
            RuleFor(t => t.VendorProductKey).NotEmpty();
        }
    }
}