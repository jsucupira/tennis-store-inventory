using System;
using System.Diagnostics.CodeAnalysis;

namespace Core.Common.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class AuthorizationValidationException : ApplicationException
    {
        public AuthorizationValidationException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}