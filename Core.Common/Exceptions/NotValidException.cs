using System;
using System.Diagnostics.CodeAnalysis;

namespace Core.Common.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class NotValidException : Exception
    {
        public NotValidException(string message): base(message)
        {
        }

        public NotValidException(string message, Exception exception): base(message, exception)
        {
        }
    }
}