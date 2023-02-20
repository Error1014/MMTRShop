using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{
 
    public class ClientsController : BaseApiController
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost(nameof(GetClientsPage))]
        public async Task<IEnumerable<ClientDTO>> GetClientsPage([FromBody] BaseFilter filter)
        {
            var users = await _clientService.GetPageClients(filter);
            return users;
        }
        [HttpGet("{id}")]
        public async Task<ClientDTO> GetClient(Guid id)
        {
            var client = await _clientService.GetClient(id);
            return client;
        }

        [HttpPost]
        public async Task<IActionResult> PostClient(ClientDTO clientDTO)
        {
            await _clientService.AddClient(clientDTO);
            return Ok(clientDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutClient(ClientDTO clientDTO)
        {
            await _clientService.Update(clientDTO);
            return Ok(clientDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _clientService.RemoveClient(id);
            return Ok($"Клиент с id={id} успешно удалён"); ;
        }
    }
}
