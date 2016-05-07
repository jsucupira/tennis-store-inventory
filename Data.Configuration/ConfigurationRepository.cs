using System;
using System.ComponentModel.Composition;
using System.Runtime.Caching;
using Core.Common;
using Core.Common.Exceptions;
using Data.Contracts;

namespace Data.Configuration
{
    [Export(typeof(IConfigurationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ICaching _caching;
        private readonly IRepository<Core.Common.Configurations.Configuration, string> _configurationRepository;

        [ImportingConstructor]
        public ConfigurationRepository(ICaching caching, IRepository<Core.Common.Configurations.Configuration, string> configurationRepository)
        {
            _caching = caching;
            _configurationRepository = configurationRepository;
        }

        public bool GetBooleanSetting(string settingKey)
        {
            string rawValue = GetSetting(settingKey);
            bool value;
            if (bool.TryParse(rawValue, out value))
                return value;
            if (rawValue == "0")
                return false;
            if (rawValue == "1")
                return true;
            return false;
        }

        public double GetDoubleSetting(string settingKey)
        {
            string rawValue = GetSetting(settingKey);
            double value;
            if (double.TryParse(rawValue, out value))
                return value;
            throw new Exception($"Could not convert Configuration item '{settingKey}' ({rawValue}) to Double.");
        }

        public int GetIntegerSetting(string settingKey)
        {
            string rawValue = GetSetting(settingKey);
            int value;
            if (int.TryParse(rawValue, out value))
                return value;
            throw new ConfigurationException($"Could not convert Configuration item '{settingKey}' ({rawValue}) to Integer.");
        }

        public string GetSetting(string settingKey)
        {
            string value = _caching.Get<string>(settingKey, Constants.CONFIGURATION_SECTION);
            if (value != null)
                return value;

            Core.Common.Configurations.Configuration item = _configurationRepository.Get(settingKey);
            if (item == null)
                throw new ConfigurationException(settingKey);

            SetCache(settingKey, item.Value);

            return item.Value;
        }

        public void RefreshCache()
        {
            _caching.RemoveAll(Constants.CONFIGURATION_SECTION);
        }

        public void SaveSetting(string key, string value)
        {
            _configurationRepository.Update(new Core.Common.Configurations.Configuration(key, value));
            SetCache(key, value);
        }

        private void SetCache(string key, object value)
        {
            DateTimeOffset dateTime = DateTimeOffset.Now.AddHours(GetIntegerSetting(Constants.CONFIGURATION_CACHE_TIME));
            _caching.Set(key, value, Constants.CONFIGURATION_SECTION, new CacheItemPolicy {AbsoluteExpiration = dateTime});
        }
    }
}