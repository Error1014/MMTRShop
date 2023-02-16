using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : Controller
    {
        private readonly IFavouriteService _favouriteService;
        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }


        [HttpGet("{clientId}")]
        public async Task<IEnumerable<FavouriteDTO>> GetCarts(Guid clientId)
        {
            var carts = await _favouriteService.GetFavourites(clientId);
            return carts;
        }

        [HttpPost]
        public async Task<IActionResult> PostCart(FavouriteDTO cartDTO)
        {
            await _favouriteService.AddFavourite(cartDTO);
            return Ok(cartDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutCart(FavouriteDTO cartDTO)
        {
            await _favouriteService.Update(cartDTO);
            return Ok(cartDTO);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            await _favouriteService.RemoveFavourite(id);
            return Ok($"Избраное с id={id} успешно удалено"); ;
        }
    }
}
