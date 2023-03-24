using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Microsoft.AspNetCore.Authorization;
using Shop.Infrastructure;
using Carts.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using XAct;
using Newtonsoft.Json.Linq;
using Shop.Infrastructure.Attributes;

namespace Carts.Api.Controllers
{
    public class CartsController : BaseApiController
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
            
        }
        [RoleAuthorize("Client")]
        [HttpGet(nameof(GetCarts))]
        public async Task<IEnumerable<CartItemDTO>> GetCarts()
        {
            var carts = await _cartService.GetCartItemsDTO();
            return carts;
        }

        [RoleAuthorize("Client")]
        [HttpPost(nameof(PostProductInCart))]
        public async Task<IActionResult> PostProductInCart(Guid productId)
        {
            await _cartService.AddProductInCart(productId);
            return Ok("Товар добавлен в корзину");
        }

        [RoleAuthorize("Client")]
        [HttpPut]
        public async Task<IActionResult> PutProductInCart(CartItemDTO cartDTO)
        {
            await _cartService.Update(cartDTO);
            return Ok(cartDTO);
        }

        [RoleAuthorize("Client")]
        [HttpPut(nameof(AddCountProductInCart))]
        public async Task<IActionResult> AddCountProductInCart(Guid cartId)
        {
            await _cartService.CartPlusOneProduct(cartId);
            return Ok("+1");
        }

        [RoleAuthorize("Client")]
        [HttpPut(nameof(RemoveCountProductInCart))]
        public async Task<IActionResult> RemoveCountProductInCart(Guid cartId)
        {
            await _cartService.CartMinusOneProduct(cartId);
            return Ok("-1");
        }

        [RoleAuthorize("Client")]
        [HttpDelete(nameof(ClearCart))]
        public async Task<IActionResult> ClearCart()
        {
            await _cartService.ClearCart();
            return Ok($"Корзина успешно очищена"); ;
        }

        [RoleAuthorize("Client")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductInCart(Guid cartItemId)
        {
            await _cartService.RemoveProductInCart(cartItemId);
            return Ok($"Успешно"); ;
        }
    }
}
