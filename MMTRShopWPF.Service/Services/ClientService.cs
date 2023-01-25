using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class ClientService
    {
        private readonly UnitOfWork _unitOfWork;
        public ClientService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Client GetClient(Order order)
        {
            return _unitOfWork.Clients.GetById(order.ClientId);
        }
    }
}
