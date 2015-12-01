using System.Linq;
using Core.Common.Exceptions;
using Core.Common.Model;

namespace Core.Common.Helpers
{
    public static class ValidateEntity
    {
        public static void Validate(this IEntity entity)
        {
            entity.VerifyValidation();
            if (entity.ValidationErrors.Any())
                throw new NotValidException(entity.ValidationErrorsMessage);
        }
    }
}