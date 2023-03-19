using Configuration.Repository.Entities;
using Configuration.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Repository.Repository
{
    public class ConfigurationRepository : Repository<ConfigurationItem, Guid>, IConfigurationRepository
    {
        private readonly ConfigurationDbContext _configurationDbContext;
        public ConfigurationRepository(ConfigurationDbContext context) : base(context)
        {
            _configurationDbContext = context;
        }

    }
}
