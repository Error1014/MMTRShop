using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace MMTRShopAPI.Controllers
{

    public class FavouritesController : BaseApiController
    {
        private readonly IFavouriteService _favouriteService;
        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [Authorize(Roles = "Admin, Client")]
        [HttpGet]
        public async Task<IEnumerable<FavouriteDTO>> GetFavourites([FromQuery] FilterByClient filter)
        {
            var carts = await _favouriteService.GetFavourites(filter);
            return carts;
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpPost]
        public async Task<IActionResult> PostFavourite(FavouriteDTO cartDTO)
        {
            await _favouriteService.AddFavourite(cartDTO);
            return Ok(cartDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutFavourite(FavouriteDTO cartDTO)
        {
            await _favouriteService.Update(cartDTO);
            return Ok(cartDTO);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourite(Guid id)
        {
            await _favouriteService.RemoveFavourite(id);
            return Ok($"Избраное с id={id} успешно удалено"); ;
        }
    }
}
