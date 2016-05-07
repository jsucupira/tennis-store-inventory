using System.Diagnostics.CodeAnalysis;
using Domain.MasterData.VendorAggregate;
using FluentValidation;

namespace Domain.MasterData.Validations
{
    [ExcludeFromCodeCoverage]
    public sealed class VendorValidator : AbstractValidator<Vendor>
    {
        public VendorValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.LastModifiedBy).NotEmpty();
        }
    }
}