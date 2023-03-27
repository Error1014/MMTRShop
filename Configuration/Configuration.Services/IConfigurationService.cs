using Configuration.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Services
{
    public interface IConfigurationService
    {
        Task<IEnumerable<ConfigurationItem>> GetConfiguration();
        Task AddConfiguration(ConfigurationItem configurationItem);
        Task UpdateConfiguration(ConfigurationItem configurationItem);
    }
}
