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

        [RoleAuthorize("Admin Client")]
        [HttpGet]
        public async Task<IEnumerable<FavouriteDTO>> GetFavourites([FromQuery] BaseFilter filter)
        {
            var carts = await _favouriteService.GetFavourites(filter);
            return carts;
        }
        [RoleAuthorize("Admin Client")]
        [HttpPost]
        public async Task<IActionResult> PostFavourite(Guid productId)
        {
            await _favouriteService.AddFavourite(productId);
            return Ok(productId);
        }

        [HttpPut]
        public async Task<IActionResult> PutFavourite(FavouriteDTO cartDTO)
        {
            await _favouriteService.Update(cartDTO);
            return Ok(cartDTO);
        }
        [RoleAuthorize("Admin Client")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFavourite(Guid productId)
        {
            await _favouriteService.RemoveFavourite(productId);
            return Ok($"Избраное с id={productId} успешно удалено"); ;
        }
    }
}
