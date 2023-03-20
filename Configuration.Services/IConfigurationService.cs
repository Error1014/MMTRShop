using Configuration.Repository.Entities;
using Microsoft.Extensions.Options;
using Shop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Services
{
    public interface IConfigurationService
    {
        Task<IOptions<SettingsConfiguration>> GetConfiguration();
        Task AddConfiguration(ConfigurationItem configurationItem);
        Task UpdateConfiguration(ConfigurationItem configurationItem);
    }
}
