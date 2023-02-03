using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class ClientService: IClientService
    {
        private readonly UnitOfWork _unitOfWork;
        public ClientService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Client> GetClient(Order order)
        {
            return await _unitOfWork.Clients.GetByIdAsync(order.ClientId);
        }
    }
}
