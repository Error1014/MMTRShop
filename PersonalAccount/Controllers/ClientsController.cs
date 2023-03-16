using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using Microsoft.AspNetCore.Authorization;
using PersonalAccountMicroservice.PersonalAccount.Services;

namespace PersonalAccountMicroservice.PersonalAccount.Api.Controllers
{

    public class ClientsController : BaseApiController
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClientsPage([FromQuery] BaseFilter filter)
        {
            var users = await _clientService.GetPageClients(filter);
            return Ok(users);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(Guid id)
        {
            var client = await _clientService.GetClient(id);
            return Ok(client);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostClient(ClientDTO clientDTO)
        {
            await _clientService.AddClient(clientDTO);
            return Ok(clientDTO);
        }
        [Authorize(Roles = "Client")]
        [HttpPut]
        public async Task<IActionResult> PutClient(ClientDTO clientDTO)
        {
            await _clientService.Update(clientDTO);
            return Ok(clientDTO);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _clientService.RemoveClient(id);
            return Ok($"Клиент с id={id} успешно удалён"); ;
        }
    }
}
