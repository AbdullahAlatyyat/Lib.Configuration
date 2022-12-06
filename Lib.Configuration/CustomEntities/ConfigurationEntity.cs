using System;

namespace Framework.Configuration.CustomEntities
{
    public class ConfigurationEntity
    {
        public string ConfigurationKey { get; set; }
        public string ConfigurationValue { get; set; }
        public string ConfigurationBlockName { get; set; }
    }
}