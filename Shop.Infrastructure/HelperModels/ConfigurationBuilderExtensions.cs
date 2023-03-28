using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.HelperModels
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddSimpleConfiguration(

        this IConfigurationBuilder builder, IDictionary<string, string> data)
        {
            data ??= new Dictionary<string, string>();
            return builder.Add(new DictionaryConfigurationSource(data));
        }
    }
}
