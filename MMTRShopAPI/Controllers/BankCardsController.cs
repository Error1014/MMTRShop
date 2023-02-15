using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankCardsController : ControllerBase
    {
        private readonly IBankCardService _bankCardService;
        public BankCardsController(IBankCardService bankCardService)
        {
            _bankCardService = bankCardService;
        }


        [HttpGet]
        public async Task<IEnumerable<BankCardDTO>> GetBankCards()
        {
            var bankCard = await _bankCardService.GetBankCards();
            return bankCard;
        }
        [HttpGet("{id}")]
        public async Task<BankCardDTO> GetBankCard(Guid id)
        {
            var bankCard = await _bankCardService.GetBankCard(id);
            return bankCard;
        }

        [HttpPost]
        public async Task<IActionResult> PostBankCard(BankCardDTO brandDTO)
        {
            await _bankCardService.AddBankCard(brandDTO);
            return Ok(brandDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutBankCard(BankCardDTO brandDTO)
        {
            await _bankCardService.Update(brandDTO);
            return Ok(brandDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankCard(Guid id)
        {
            await _bankCardService.Remove(id);
            return Ok($"Банковская карта с id={id} успешно удалена");
        }
    }
}
