using System;
using Domain.MasterData.ProductAggregate;
using FluentValidation;

namespace Domain.MasterData.Validations
{
    public sealed class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.ProductCategoryId).NotEqual(0);
            RuleFor(t => t.LastModifiedBy).NotEmpty();
        }
    }
}