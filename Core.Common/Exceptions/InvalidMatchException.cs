﻿using System;
using System.Runtime.Serialization;

namespace Core.Common.Exceptions
{
    public class InvalidMatchException : Exception
    {
        public InvalidMatchException()
        {
        }

        public InvalidMatchException(string message)
            : base(message)
        {
        }

        public InvalidMatchException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected InvalidMatchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}