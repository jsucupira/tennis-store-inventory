using System.Collections.Generic;
using FluentValidation.Results;

namespace Core.Common.Model
{
    public interface IEntity
    {
        IEnumerable<ValidationFailure> ValidationErrors { get; }
        string ValidationErrorsMessage { get; }
        void VerifyValidation();
    }
}