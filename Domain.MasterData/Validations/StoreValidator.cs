using System.Diagnostics.CodeAnalysis;
using Core.Common.Validations;
using Domain.MasterData.StoreAggregate;
using FluentValidation;

namespace Domain.MasterData.Validations
{
    [ExcludeFromCodeCoverage]
    public sealed class StoreValidator : AbstractValidator<Store>
    {
        public StoreValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.LastModifiedBy).NotEmpty();
            RuleFor(t => t.ManagerEmail).Must(t => string.IsNullOrEmpty(t) || t.IsValidEmail());
            RuleFor(t => t.WebSiteUrl).Must(t => string.IsNullOrEmpty(t) || t.IsValidUrl());
        }
    }
}