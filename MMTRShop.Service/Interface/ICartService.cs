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
        Task<IEnumerable<CartDTO>> GetAll();
        Task<IEnumerable<CartDTO>> GetCarts(FilterByClient filter);
        Task<CartDTO> GetCart(Guid cartId);
        Task AddProductInCart(CartDTO cartDTO);
        Task Update(CartDTO cartDTO);
        Task RemoveCart(Guid id);
        Task CartMinusOneProduct(Guid id);
        Task CartPlusOneProduct(Guid id);
        Task ClearCart(Guid clientId);
    }
}
