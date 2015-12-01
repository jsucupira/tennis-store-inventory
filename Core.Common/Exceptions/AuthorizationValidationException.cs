using System;

namespace Core.Common.Exceptions
{
    [Serializable]
    public class AuthorizationValidationException : ApplicationException
    {
        public AuthorizationValidationException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}