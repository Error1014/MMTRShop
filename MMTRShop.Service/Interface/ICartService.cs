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
        Task<IEnumerable<Cart>> GetCart(Guid clientId);
        Task AddProductInCart(Guid productId);
        Task CartMinusOneProduct(Guid id);
        Task CartPlusOneProduct(Guid id);
        Task ClearCart(Guid clientId);
    }
}
