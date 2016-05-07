using System.Diagnostics.CodeAnalysis;
using Domain.MasterData.VendorAggregate;
using FluentValidation;

namespace Domain.MasterData.Validations
{
    [ExcludeFromCodeCoverage]
    public class VendorProductValidator : AbstractValidator<VendorProduct>
    {
        public VendorProductValidator()
        {
            RuleFor(t => t.StandardPrice).GreaterThan(0);
            RuleFor(t => t.VendorId).NotEmpty();
            RuleFor(t => t.VendorProductKey).NotEmpty();
            RuleFor(t => t.Id).NotEmpty();
        }
    }
}