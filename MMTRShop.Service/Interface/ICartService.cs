using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
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
        Task<IEnumerable<CartDTO>> GetAllProductInCart(Guid clientId);
        Task<IEnumerable<CartDTO>> GetCarts(FilterByClient filter);
        Task<CartDTO> GetCart(Guid cartId);
        Task<CartDTO> GetCartByClientIdAndProductId(Guid clientId,Guid productId);
        Task AddProductInCart(CartDTO cartDTO);
        Task Update(CartDTO cartDTO);
        Task RemoveProductInCart(Guid ClientId,Guid productId);
        Task CartMinusOneProduct(Guid id);
        Task CartPlusOneProduct(Guid id);
        Task ClearCart(Guid clientId);
    }
}
