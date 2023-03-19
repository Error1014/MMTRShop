using Configuration.Repository.Entities;
using Shop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationMicroservice.Configuration.Services
{
    public interface IConfigurationService
    {
        Task<IEnumerable<ConfigurationItem>> GetConfiguration();
        Task AddConfiguration(ConfigurationItem configurationItem);
        Task UpdateConfiguration(ConfigurationItem configurationItem);
    }
}
