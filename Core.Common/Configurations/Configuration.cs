namespace Core.Common.Configurations
{
    public class Configuration
    {
        private Configuration() { }

        public Configuration(string name, string configurationType, string value)
        {
            Name = name;
            Value = value;
            ConfigurationType = configurationType;
        }

        public string Name { get; private set; }
        public string ConfigurationType { get; private set; }
        public string Value { get; private set; }
    }
}