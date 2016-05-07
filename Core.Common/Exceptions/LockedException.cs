using System;
using System.Diagnostics.CodeAnalysis;

namespace Core.Common.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class LockedException : Exception
    {
        public LockedException(string message) : base(message)
        {
        }
    }
}