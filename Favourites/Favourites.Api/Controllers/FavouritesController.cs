using Favourites.Services;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure;
using Shop.Infrastructure.Attributes;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Favourites.Api.Controllers
{

    public class FavouritesController : BaseApiController
    {
        private readonly IFavouriteService _favouriteService;
        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [RoleAuthorize("Admin  Client")]
        [HttpGet]
        public async Task<IEnumerable<FavouriteDTO>> GetFavourites([FromQuery] FilterByClient filter)
        {
            var carts = await _favouriteService.GetFavourites(filter);
            return carts;
        }
        [RoleAuthorize("Admin  Client")]
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
