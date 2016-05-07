using System.Diagnostics.CodeAnalysis;
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
        }
    }
}