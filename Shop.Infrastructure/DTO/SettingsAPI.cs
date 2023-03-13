using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DTO
{
    public class SettingsAPI
    {
        public const string Settings = "SettingsAPI";
        public int RestrictionOfGoodsInCart { get; set; } //Ограничение количества товаров 
        public int QuantityOfProductToDisplay { get; set; }//Количество товара при котором показывается его количество пользователю
    }
}
