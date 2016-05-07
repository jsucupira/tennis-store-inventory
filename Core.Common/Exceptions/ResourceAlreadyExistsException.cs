using System;
using System.Diagnostics.CodeAnalysis;

namespace Core.Common.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ResourceAlreadyExistsException : ApplicationException
    {
        public ResourceAlreadyExistsException(string message): base(message)
        {
        }

        public ResourceAlreadyExistsException(string message, Exception exception): base(message, exception)
        {
        }
    }
}