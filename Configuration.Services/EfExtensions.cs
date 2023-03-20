using Configuration.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Services
{
    public static class EfExtensions
    {
        public static IConfigurationBuilder AddEfConfiguration(this IConfigurationBuilder configurationBuilder,
                                                               Action<DbContextOptionsBuilder> optionsAction)
        {
            return configurationBuilder.Add(new EfConfigurationSource(optionsAction));
        }
    }
}
