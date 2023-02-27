using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Exceptions;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using MMTRShop.Repository.Entities;

namespace MMTRShopAPI.Controllers
{
    [Authorize(Roles = "Admin, Client")]
    public class CartsController : BaseApiController
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize(Roles = "Admin, Client")]
        [HttpGet]
        public async Task<IEnumerable<CartDTO>> GetCartsPage([FromQuery]FilterByClient filter)
        {
            var carts = await _cartService.GetCartsDTO(filter);
            return carts;
        }

        [Authorize(Roles = "Admin, Client")]
        [HttpPost]
        public async Task<IActionResult> PostProductInCart(CartDTO cartDTO)
        {
            await _cartService.AddProductInCart(cartDTO);
            return Ok(cartDTO);
        }

        [Authorize(Roles = "Admin, Client")]
        [HttpPut]
        public async Task<IActionResult> PutProductInCart(CartDTO cartDTO)
        {
            await _cartService.Update(cartDTO);
            return Ok(cartDTO);
        }

        [Authorize(Roles = "Admin, Client")]
        [HttpPut(nameof(AddCountProductInCart))]
        public async Task<IActionResult> AddCountProductInCart(Guid cartId)
        {
            await _cartService.CartPlusOneProduct(cartId);
            return Ok("+1");
        }

        [Authorize(Roles = "Admin, Client")]
        [HttpPut(nameof(RemoveCountProductInCart))]
        public async Task<IActionResult> RemoveCountProductInCart(Guid cartId)
        {
            await _cartService.CartMinusOneProduct(cartId);
            return Ok("-1");
        }

        [Authorize(Roles = "Admin, Client")]
        [HttpDelete(nameof(ClearCart))]
        public async Task<IActionResult> ClearCart()
        {
            await _cartService.ClearCart(UserId);
            return Ok($"Корзина успешно очищена"); ;
        }

        [Authorize(Roles = "Admin, Client")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductInCart(Guid productId)
        {
            await _cartService.RemoveProductInCart(UserId, productId);
            return Ok($"Успешно"); ;
        }
    }
}
