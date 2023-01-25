using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class AccountService
    {
        private UnitOfWork _unitOfWork;
        public AccountService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User GetUser()
        {
            return _unitOfWork.Users.Find(u=>u.Id == AccountManager.User.Id);
        }
        public Client GetClient()
        {
            return _unitOfWork.Clients.Find(c=>c.Id == AccountManager.Client.Id);
        }
        public void Save()
        {
            _unitOfWork.Users.Save();
            _unitOfWork.Clients.Save();
        }
    }
}
