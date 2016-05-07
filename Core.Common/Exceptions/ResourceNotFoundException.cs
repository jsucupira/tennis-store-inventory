using System;
using System.Diagnostics.CodeAnalysis;

namespace Core.Common.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message)
        {

        }
    }
}