using ConfigurationMicroservice.Configuration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationMicroservice.Configuration.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConfigurationSettingsController : BaseApiController
    {
        private readonly IClientSettingsService _configurationService;
        public ConfigurationSettingsController(IClientSettingsService configurationService)
        {
            _configurationService = configurationService;
        }
        [HttpPut(nameof(PutRestrictionOfGoodsInCart))]
        public async Task<IActionResult> PutRestrictionOfGoodsInCart(int value)
        {
            _configurationService.UpdateRestrictionOfGoodsInCart(value);
            return Ok();
        }
        [HttpPut(nameof(PutQuantityOfProductToDisplay))]
        public async Task<IActionResult> PutQuantityOfProductToDisplay(int value)
        {
            _configurationService.UpdateQuantityOfProductToDisplay(value);
            return Ok();
        }
    }
}
