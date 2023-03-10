using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IClientSettingsService
    {
        int RestrictionOfGoodsInCart { get; set; }
        int QuantityOfProductToDisplay { get; set; }

        void UpdateRestrictionOfGoodsInCart(int value);
        void UpdateQuantityOfProductToDisplay(int value);
    }
}
