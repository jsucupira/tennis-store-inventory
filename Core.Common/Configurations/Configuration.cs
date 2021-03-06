﻿using System.Diagnostics.CodeAnalysis;

namespace Core.Common.Configurations
{
    [ExcludeFromCodeCoverage]
    public class Configuration
    {
        private Configuration() { }

        public Configuration(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}