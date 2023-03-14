using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using System;

namespace MMTRShopAPI.Controllers
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
