using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Core.Common.Exceptions;

namespace Core.Common.Configurations
{
    public static class ConfigurationsSelector
    {
        private static readonly ObjectCache _cache = MemoryCache.Default;

        public static List<Configuration> GetAll()
        {
            List<Configuration> items;
            if (_cache.Any())
            {
                items = _cache.Select(t => new Configuration(t.Key, t.Value.ToString())).ToList();
                return items;
            }

            items = ConfigurationContextFactory.Create().GetAll();

            foreach (Configuration configuration in items)
                SetCache(configuration.Key, configuration.Value);

            return items;
        }

        public static bool GetBooleanSetting(string settingKey)
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

        public static double GetDoubleSetting(string settingKey)
        {
            string rawValue = GetSetting(settingKey);
            double value;
            if (double.TryParse(rawValue, out value))
                return value;
            throw new Exception($"Could not convert Configuration item '{settingKey}' ({rawValue}) to Double.");
        }

        public static int GetIntegerSetting(string settingKey)
        {
            string rawValue = GetSetting(settingKey);
            int value;
            if (int.TryParse(rawValue, out value))
                return value;
            throw new ConfigurationException($"Could not convert Configuration item '{settingKey}' ({rawValue}) to Integer.");
        }

        public static string GetSetting(string settingKey)
        {
            string cacheKey = settingKey;
            string value = _cache.Get(cacheKey) as string;
            if (value != null)
                return value;

            IConfigurationContext context = ConfigurationContextFactory.Create();
            Configuration item = context.GetItem(settingKey);
            if (item == null)
                throw new ConfigurationException(settingKey);

            SetCache(cacheKey, item.Value);

            return item.Value;
        }

        public static void RefreshCache()
        {
            Task.Factory.StartNew(() =>
            {
                foreach (KeyValuePair<string, object> item in _cache)
                    _cache.Remove(item.Key);
            });
        }

        public static void SaveSetting(string key, string value)
        {
            IConfigurationContext context = ConfigurationContextFactory.Create();
            context.Save(new Configuration(key, value));
            SetCache(key, value);
        }

        private static void SetCache(string key, object value)
        {
            DateTimeOffset dateTime = DateTimeOffset.Now.AddMinutes(15);
            _cache.Set(key, value, new CacheItemPolicy { AbsoluteExpiration = dateTime });
        }
    }
}