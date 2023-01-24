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
        private readonly UnitOfWork UnitOfWork;
        public AccountService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public User GetUser()
        {
            return UnitOfWork.Users.Find(u=>u.Id == AccountManager.User.Id);
        }
        public Client GetClient()
        {
            return UnitOfWork.Clients.Find(c=>c.Id == AccountManager.Client.Id);
        }
        public void Save()
        {
            UnitOfWork.Users.Save();
            UnitOfWork.Clients.Save();
        }
    }
}
