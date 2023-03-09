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
        Task<IEnumerable<CartItemDTO>> GetCartItemsDTO();
        Task<CartItemDTO> GetCart(Guid cartId);
        Task AddProductInCart(Guid productId);
        Task Update(CartItemDTO cartDTO);
        Task RemoveProductInCart(Guid productId);
        Task CartMinusOneProduct(Guid id);
        Task CartPlusOneProduct(Guid id);
        Task ClearCart();
    }
}
