using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientDTO>> GetUsersPage()
        {
            //понять как передать фильтр в качестве параметра когтроллера
            BaseFilter filter = new BaseFilter(1, 5);
            var users = await _clientService.GetPageClients(filter);
            return users;
        }
        [HttpGet("{id}")]
        public async Task<ClientDTO> GetUser(Guid id)
        {
            var client = await _clientService.GetClient(id);
            return client;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(ClientDTO clientDTO)
        {
            await _clientService.AddClient(clientDTO);
            return Ok(clientDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(ClientDTO clientDTO)
        {
            await _clientService.Update(clientDTO);
            return Ok(clientDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _clientService.RemoveClient(id);
            return Ok($"Клиент с id={id} успешно удалён"); ;
        }
    }
}
