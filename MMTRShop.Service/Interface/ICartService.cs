using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
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
        Task<IEnumerable<CartDTO>> GetCartsDTO(Guid clientId);
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
