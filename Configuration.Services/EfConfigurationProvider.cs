using Configuration.Repository;
using Configuration.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Services
{
    public class EfConfigurationProvider : ConfigurationProvider
    {
        public Action<DbContextOptionsBuilder> OptionsAction { get; }

        public EfConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ConfigurationDbContext>();

            OptionsAction(builder);

            using (var dbContext = new ConfigurationDbContext(builder.Options))
            {
                

                Data = !dbContext.ConfigurationItem.Any()
                    ? CreateAndSaveDefaultValues(dbContext)
                    : dbContext.ConfigurationItem.ToDictionary(c => c.Key, c => c.Value);
            }
        }
        private static IDictionary<string, string> CreateAndSaveDefaultValues(
        ConfigurationDbContext dbContext)
        {
            var configValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "JwtOptions:Key", "111" },
                { "JwtOptions:Issuer", "111" },
                { "JwtOptions:Audience", "111" }
            };


            dbContext.ConfigurationItem.AddRange(configValues
                .Select(kvp => new ConfigurationItem
                {
                    Key = kvp.Key,
                    Value = kvp.Value
                })
                .ToArray());

            dbContext.SaveChanges();

            return configValues;
        }
    }
}
