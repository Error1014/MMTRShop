using Microsoft.Extensions.Options;
using Shop.Infrastructure.DTO;

namespace ConfigurationMicroservice.Configuration.Services
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
