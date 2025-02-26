using Framework.Configuration.CustomEntities;
using Framework.Configuration.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Framework.Configuration
{
    internal class ConfigurationManagerRepository
    {
        public static List<ConfigurationEntity> GetEnvironmentSettings()
        {
            IList<ConfigurationEntity> configurations = new List<ConfigurationEntity>();
            using (ConfigurationContext dbContext = new ConfigurationContext())
            {
                dbContext.Database.EnsureCreated();

                var dbList = dbContext.Configurations.Include(e => e.Block).OrderBy(e => e.BlockId).ToList();
                foreach (var entity in dbList)
                {
                    configurations.Add(new ConfigurationEntity()
                    {
                        ConfigurationKey = entity.KeyName,
                        ConfigurationValue = entity.KeyValue,
                        ConfigurationBlockName = entity.Block.Name
                    });
                }
            }
            return configurations.ToList();
        }
    }
}