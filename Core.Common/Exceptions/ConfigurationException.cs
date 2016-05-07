using System;
using System.Diagnostics.CodeAnalysis;

namespace Core.Common.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string key) : base($"The configuration {key} was not found.")
        {
        }
    }
}