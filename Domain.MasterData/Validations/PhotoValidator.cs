using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.MasterData.ProductAggregate;
using FluentValidation;

namespace Domain.MasterData.Validations
{
    public class PhotoValidator : AbstractValidator<Photo>
    {
        public PhotoValidator()
        {
            RuleFor(t => t.ProductId).NotEmpty();
            RuleFor(t => t.LastModifiedBy).NotEmpty();
        }
    }
}
