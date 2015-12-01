using System;

namespace Core.Common.Exceptions
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string key) : base($"The configuration {key} was not found.")
        {
        }
    }
}