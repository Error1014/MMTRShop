using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MMTRShop.Service.Interface;
using Newtonsoft.Json;
using Shop.Infrastructure.DTO;
using System;

namespace MMTRShop.Service.Services
{
    public class ClientSettingsService:IClientSettingsService
    {
        private readonly SettingsAPI _optionsDelegate;
        public SettingsAPI SettingsAPI { get; set; }
        public ClientSettingsService(IOptions<SettingsAPI> optionsDelegate)
        {
            _optionsDelegate = optionsDelegate.Value;
            SettingsAPI = _optionsDelegate;
        }

        public void UpdateRestrictionOfGoodsInCart(int value)
        {
            _optionsDelegate.RestrictionOfGoodsInCart = value;
        }

        public void UpdateQuantityOfProductToDisplay(int value)
        {
            _optionsDelegate.QuantityOfProductToDisplay = value;
        }
    }
}
