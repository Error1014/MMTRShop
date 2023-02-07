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
        Task AddProductInCart(Product product);
        Task CartMinusOneProduct(Guid id);
        Task CartPlusOneProduct(Guid id);
        Task CartRemoveProduct(Guid id);
        Task ClearCart();
    }
}
