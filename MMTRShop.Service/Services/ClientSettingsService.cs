using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMTRShop.Service.Interface;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class ClientSettingsService:IClientSettingsService
    {
        private IConfiguration _configuration;
        public int RestrictionOfGoodsInCart { get; set; }
        public int QuantityOfProductToDisplay { get; set; }
        public ClientSettingsService() { 

        }
        public ClientSettingsService(IConfiguration configuration)
        {
            _configuration = configuration;
            RestrictionOfGoodsInCart = int.Parse(_configuration["ClientSettingsService:RestrictionOfGoodsInCart"]);
            QuantityOfProductToDisplay = int.Parse(_configuration["ClientSettingsService:QuantityOfProductToDisplay"]);
        }

        public void UpdateRestrictionOfGoodsInCart(int value)
        {
            RestrictionOfGoodsInCart = value;
        }

        public void UpdateQuantityOfProductToDisplay(int value)
        {
            QuantityOfProductToDisplay = value;
        }
    }
}
