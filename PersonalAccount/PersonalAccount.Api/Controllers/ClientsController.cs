﻿using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using Microsoft.AspNetCore.Authorization;
using Shop.Infrastructure;
using PersonalAccount.Services;
using Shop.Infrastructure.Attributes;

namespace PersonalAccount.Api.Controllers
{

    public class ClientsController : BaseApiController
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [RoleAuthorize("Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClientsPage([FromQuery] BaseFilter filter)
        {
            var users = await _clientService.GetPageClients(filter);
            return Ok(users);
        }
        [RoleAuthorize("Admin")]
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
        [RoleAuthorize("Client")]
        [HttpPut]
        public async Task<IActionResult> PutClient(ClientDTO clientDTO)
        {
            await _clientService.Update(clientDTO);
            return Ok(clientDTO);
        }
        [RoleAuthorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _clientService.RemoveClient(id);
            return Ok($"Клиент с id={id} успешно удалён"); ;
        }
    }
}
