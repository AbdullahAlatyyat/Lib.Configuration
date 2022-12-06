using Framework.Configuration.Constants;
using Microsoft.Extensions.Configuration;
using ConfigurationSettings = Framework.Configuration.ConfigurationSettings;

namespace Framework.Configuration
{
    public static class ConfigurationLibManager
    {
        public static void InitializeEnvironmentConfigurations(IConfiguration config)
        {
            var configSection = config.GetSection("ConfigurationLib");
            ConfigurationConstants.ConnectionString = configSection["ConnectionString"];
            ConfigurationConstants.EntitiesNamespace = configSection["EntitiesNamespace"];

            EnvironmentConfiguration.Init();
        }

        public static ConfigurationSettings EnvironmentConfigurations
        {
            get
            {
                return EnvironmentConfiguration.GetInstance();
            }
        }

        public static void Dispose()
        {
            EnvironmentConfiguration.Dispose();
        }

        public static ConfigurationSettings GetEnvironmentConfigurations()
        {
            EnvironmentConfiguration.Init();
            return EnvironmentConfigurations;
        }
    }
}