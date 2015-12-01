using System;

namespace Core.Common.Exceptions
{
    [Serializable]
    public class NotValidException : ApplicationException
    {
        public NotValidException(string message): base(message)
        {
        }

        public NotValidException(string message, Exception exception): base(message, exception)
        {
        }
    }
}