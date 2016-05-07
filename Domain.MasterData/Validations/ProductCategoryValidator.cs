using System.Diagnostics.CodeAnalysis;
using Domain.MasterData.ProductAggregate;
using FluentValidation;

namespace Domain.MasterData.Validations
{
    [ExcludeFromCodeCoverage]
    public sealed class ProductCategoryValidator : AbstractValidator<ProductCategory>
    {
        public ProductCategoryValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Name).NotEmpty();
        }
    }
}