﻿namespace Data.Contracts
{
    public interface IConfigurationRepository
    {
        bool GetBooleanSetting(string settingKey);
        double GetDoubleSetting(string settingKey);
        int GetIntegerSetting(string settingKey);
        string GetSetting(string settingKey);
        void RefreshCache();
        void SaveSetting(string key, string value);
    }
}