using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{

    public class FavouritesController : BaseApiController
    {
        private readonly IFavouriteService _favouriteService;
        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }


        [HttpPost(nameof(GetFavourites))]
        public async Task<IEnumerable<FavouriteDTO>> GetFavourites([FromBody] FilterByClient filter)
        {
            var carts = await _favouriteService.GetFavourites(filter);
            return carts;
        }

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
