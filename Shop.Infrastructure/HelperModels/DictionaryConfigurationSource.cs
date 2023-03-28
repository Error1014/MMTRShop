using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.HelperModels
{
    public class DictionaryConfigurationSource : IConfigurationSource
    {
        private readonly IDictionary<string, string> _data;

        public DictionaryConfigurationSource(IDictionary<string, string> data)
            => _data = data;

        public IConfigurationProvider Build(IConfigurationBuilder builder)
            => new DictionaryConfigurationProvider(_data);
    }
}
