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


namespace Carts.Api.Controllers
{
    public class CartsController : BaseApiController
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
            
        }
        private async void Autorization(string role)
        {
            var token = ViewData["Authorization"];
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:7226/api/Authentication/Autorize?role=Client", JsonContent.Create(""));
            string responseBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
        }
        [HttpGet(nameof(GetCarts))]
        public async Task<ActionResult<IEnumerable<CartItemDTO>>> GetCarts()
        {
            Autorization("Client");
            var carts = await _cartService.GetCartItemsDTO();
            return Ok(carts);
        }

        [HttpPost(nameof(PostProductInCart))]
        public async Task<IActionResult> PostProductInCart(Guid productId)
        {
            Autorization("Client");
            await _cartService.AddProductInCart(productId);
            return Ok("Товар добавлен в корзину");
        }

        [HttpPut]
        public async Task<IActionResult> PutProductInCart(CartItemDTO cartDTO)
        {
            Autorization("Client");
            await _cartService.Update(cartDTO);
            return Ok(cartDTO);
        }

        [HttpPut(nameof(AddCountProductInCart))]
        public async Task<IActionResult> AddCountProductInCart(Guid cartId)
        {
            Autorization("Client");
            await _cartService.CartPlusOneProduct(cartId);
            return Ok("+1");
        }

        [HttpPut(nameof(RemoveCountProductInCart))]
        public async Task<IActionResult> RemoveCountProductInCart(Guid cartId)
        {
            Autorization("Client");
            await _cartService.CartMinusOneProduct(cartId);
            return Ok("-1");
        }

        [HttpDelete(nameof(ClearCart))]
        public async Task<IActionResult> ClearCart()
        {
            Autorization("Client");
            await _cartService.ClearCart();
            return Ok($"Корзина успешно очищена"); ;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductInCart(Guid cartItemId)
        {
            Autorization("Client");
            await _cartService.RemoveProductInCart(cartItemId);
            return Ok($"Успешно"); ;
        }
    }
}
