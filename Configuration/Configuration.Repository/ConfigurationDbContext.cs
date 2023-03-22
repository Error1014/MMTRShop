using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration.Repository.Entities;

namespace Configuration.Repository
{
    public class ConfigurationDbContext:DbContext
    {
        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options) : base(options)
        {

        }
        public DbSet<ConfigurationItem> ConfigurationItem { get; set; }
    }
}
