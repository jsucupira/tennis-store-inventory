using FluentValidation;
using System;
using Core.Common.Validations;
using Domain.MasterData.StoreAggregate;

namespace Domain.MasterData.Validations
{
    public class StoreContactValidator : AbstractValidator<StoreContact>
    {
        public StoreContactValidator()
        {
            RuleFor(t => t.StoreId).NotEqual(Guid.Empty);
            RuleFor(t => t.EmailAddress).NotEmpty();
            RuleFor(t => t.EmailAddress).Must(t => t.IsValidEmail());
        }
    }
}