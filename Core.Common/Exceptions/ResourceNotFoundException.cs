using System;

namespace Core.Common.Exceptions
{
    [Serializable]
    public class ResourceNotFoundException : ApplicationException
    {
        public ResourceNotFoundException(string message): base(message)
        {
        }

        public ResourceNotFoundException(string message, Exception exception): base(message, exception)
        {
        }
    }
}