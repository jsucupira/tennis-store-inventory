using System;

namespace Core.Common.Exceptions
{
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