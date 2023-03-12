using Microsoft.Extensions.Configuration;
using MMTRShop.Service.Interface;
using Newtonsoft.Json;
using Shop.Infrastructure.DTO;
using System;

namespace MMTRShop.Service.Services
{
    public class ClientSettingsService:IClientSettingsService
    {
        private string path = "Settings.json";
        public SettingsAPI SettingsAPI { get; set; }
        public ClientSettingsService()
        {
            string json = File.ReadAllText(path);
            SettingsAPI = JsonConvert.DeserializeObject<SettingsAPI>(json);
        }

        private async Task WriteData()
        {
            string json = JsonConvert.SerializeObject(SettingsAPI);
            File.WriteAllText(path,json);

        }

        public async Task UpdateRestrictionOfGoodsInCart(int value)
        {
            SettingsAPI.RestrictionOfGoodsInCart = value;
            await WriteData();
        }

        public async Task UpdateQuantityOfProductToDisplay(int value)
        {
            SettingsAPI.QuantityOfProductToDisplay = value;
            await WriteData();
        }
    }
}
