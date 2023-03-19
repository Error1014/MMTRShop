using Configuration.Repository.Entities;
using Configuration.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Repository.Interfaces
{
    public interface IConfigurationRepository : IRepository<ConfigurationItem, Guid>
    {
    }
}
