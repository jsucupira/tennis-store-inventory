using Core.Common.Model;

namespace Core.Common.Configurations
{
    public static class ConfigurationContextFactory
    {
        public static IConfigurationContext Create()
        {
            return MefBase.Resolve<IConfigurationContext>();
        }
    }
}