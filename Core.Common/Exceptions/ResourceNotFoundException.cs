using System;

namespace Core.Common.Exceptions
{
    [Serializable]
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message)
        {

        }
    }
}