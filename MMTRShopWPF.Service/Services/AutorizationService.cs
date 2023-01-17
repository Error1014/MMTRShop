using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;

namespace MMTRShopWPF.Service.Services
{
    public class AutorizationService
    {
        UnitOfWork UnitOfWork { get; set; }
        public AutorizationService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public bool CheckCorrectLoginPassword(string login,string password)
        {
            bool isOk = false;
            var users = UnitOfWork.Users.GetAll();
            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    isOk = true;
                    break;
                }
            }
            return isOk;
        }

        public Guid GetUserId(string login, string password)
        {
            var users = UnitOfWork.Users.GetAll();
            foreach (var user in users)
            {
                if (login==user.Login && password==user.Password)
                {
                    return user.Id;
                }
            }
            return Guid.Empty;
        }
        public bool IsCheckUserInDB(string login)
        {
            var users = UnitOfWork.Users.GetAll();
            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCheckEqualTwoPassword(string password, string password2)
        {
            return password==password2;
        }

        public void AddNewClientInDB(User user,Client client)
        {
            UnitOfWork.Users.Add(user);
            UnitOfWork.Users.Save();
            UnitOfWork.Clients.Add(client);
            UnitOfWork.Clients.Save();
        }
    }
}
