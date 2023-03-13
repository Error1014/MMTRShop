using Shop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IClientSettingsService
    {
        SettingsAPI SettingsAPI { get; set; }
        void UpdateRestrictionOfGoodsInCart(int value);
        void UpdateQuantityOfProductToDisplay(int value);
    }
}
