using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetCart();
        void AddProductInCart(Product product);
        void CartMinusOneProduct(Guid id);
        void CartPlusOneProduct(Guid id);
        void CartRemoveProduct(Guid id);

        void ClearCart();
    }
}
