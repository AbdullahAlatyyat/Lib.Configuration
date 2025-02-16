using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Framework.Configuration.Constants;

namespace Framework.Configuration
{
    public class EnvironmentConfiguration
    {
        private static ConfigurationSettings instance;

        private static object syncRoot = new object();

        private EnvironmentConfiguration() { }

        internal static void Init()
        {
            instance = GetEnvironmentSettings();
        }

        public static ConfigurationSettings GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurationSettings();
                    }
                }
            }

            return instance;
        }

        internal static void Dispose()
        {
            instance = null;
        }

        internal static ConfigurationSettings GetEnvironmentSettings()
        {
            ConfigurationSettings environmentSet = new ConfigurationSettings();
            var environmentSettings = ConfigurationManagerRepository.GetEnvironmentSettings();

            var entities = from t in Assembly.GetExecutingAssembly().GetTypes()
                           where t.IsClass && t.Namespace == ConfigurationConstants.EntitiesNamespace
                           select t;

            foreach (var entity in entities)
            {
                var properties = entity.GetProperties();
                var instanceOfEntity = Activator.CreateInstance(entity);

                foreach (var property in properties)
                {
                    var confValue = environmentSettings.Where(e => e.ConfigurationKey == property.Name && entity.Name == e.ConfigurationBlockName).FirstOrDefault()?.ConfigurationValue;

                    var propType = property.PropertyType;
                    var converter = TypeDescriptor.GetConverter(propType);
                    if (confValue != null)
                    {
                        var convertedObject = converter.ConvertFromString(confValue);
                        property.SetValue(instanceOfEntity, convertedObject);
                    }
                }

                environmentSet.GetType().GetProperty(entity.Name).SetValue(environmentSet, instanceOfEntity);
            }

            return environmentSet;
        }
    }
}