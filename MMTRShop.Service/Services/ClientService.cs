using AutoMapper;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Exceptions;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Authentication;
using System.Security.Claims;
using Shop.Infrastructure;
using Shop.Infrastructure.Interface;

namespace MMTRShop.Service.Services
{
    public class ClientService: IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserSessionGetter _userSession;
        public ClientService(IUnitOfWork unitOfWork, IMapper mapper, UserSession userSession)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userSession = userSession;
        }
        public async Task AddClient(ClientDTO clientDTO)
        {
            var chekUser = await _unitOfWork.Users.FindAsync(u => u.Login == clientDTO.Login);
            if (chekUser != null)
            {
                throw new DublicateException("Пользователь с таким логином уже существует");
            }
            clientDTO.Password = GeneratorHash.GetHash(clientDTO.Password);
            var client = _mapper.Map<Client>(clientDTO);
            _unitOfWork.Clients.Add(client);
            await Save();
            client = await _unitOfWork.Clients.FindAsync(u => u.Login == client.Login);
            _unitOfWork.Carts.Add(new Cart(client.Id));
            _unitOfWork.Carts.Save();
        }

        public async Task<IEnumerable<ClientDTO>> GetPageClients(BaseFilter filter)
        {
            var clients = await _unitOfWork.Clients.GetClientsPage(filter);
            var result = _mapper.Map<IEnumerable<ClientDTO>>(clients);
            return result;
        }

        public async Task<ClientDTO> GetClient(Guid clientId)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(clientId);
            if (client == null)
            {
                throw new NotFoundException("Клиент не найден");
            }
            var result = _mapper.Map<ClientDTO>(client);
            return result;
        }

        
        public async Task RemoveClient(Guid clientId)
        {
            var client = GetClient(clientId);
            _unitOfWork.Clients.Remove(clientId);
            await Save();
        }

        public async Task Save() 
        {
            await _unitOfWork.Clients.SaveAsync();
        }

        public async Task Update(ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            client.Id = _userSession.UserId;
            client.Password = GeneratorHash.GetHash(clientDTO.Password);
            _unitOfWork.Clients.Update(client);
            await Save();
        }
    }
}
