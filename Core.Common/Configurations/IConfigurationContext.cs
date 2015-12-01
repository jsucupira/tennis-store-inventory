using System.Collections.Generic;

namespace Core.Common.Configurations
{
    public interface IConfigurationContext
    {
        List<Configuration> GetAll();
        Configuration GetItem(string key);
        void Save(Configuration configuration);
    }
}