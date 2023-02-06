using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class AccountService:IAccountService
    {
        private IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUser()
        {
            return await _unitOfWork.Users.FindAsync(u => u.Id == AccountManager.User.Id);
        }
        public async Task<Client> GetClient()
        {
            return await _unitOfWork.Clients.FindAsync(c => c.Id == AccountManager.Client.Id);
        }
        public void Save()
        {
            _unitOfWork.Users.Save();
            _unitOfWork.Clients.Save();
        }
    }
}
