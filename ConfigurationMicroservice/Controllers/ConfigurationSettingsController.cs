using ConfigurationMicroservice.Configuration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure;
using Shop.Infrastructure.DTO;

namespace ConfigurationMicroservice.Configuration.Api.Controllers
{
    public class ConfigurationSettingsController : BaseApiController
    {
        private readonly IClientSettingsService _configurationService;
        public ConfigurationSettingsController(IClientSettingsService configurationService)
        {
            _configurationService = configurationService;
        }
        [HttpGet(nameof(GetConfiguration))]
        public async Task<ActionResult<SettingsAPI>> GetConfiguration()
        {
            return Ok(_configurationService.SettingsAPI);
        }
        [HttpGet(nameof(GetRestrictionOfGoodsInCart))]
        public async Task<ActionResult<SettingsAPI>> GetRestrictionOfGoodsInCart()
        {
            return Ok(_configurationService.SettingsAPI);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut(nameof(PutRestrictionOfGoodsInCart))]
        public async Task<IActionResult> PutRestrictionOfGoodsInCart(int value)
        {
            _configurationService.UpdateRestrictionOfGoodsInCart(value);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut(nameof(PutQuantityOfProductToDisplay))]
        public async Task<IActionResult> PutQuantityOfProductToDisplay(int value)
        {
            _configurationService.UpdateQuantityOfProductToDisplay(value);
            return Ok();
        }
    }
}
