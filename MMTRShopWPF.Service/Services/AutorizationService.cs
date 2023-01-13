using MMTRShopWPF.Model.Models;
using System;

namespace MMTRShopWPF.Service.Services
{
    public class AutorizationService:BaseService
    {
        public static bool CheckCorrectLoginPassword(string login,string password)
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

        public static Guid GetUserId(string login, string password)
        {
            var users = UnitOfWork.Users.GetAll();
            foreach (var user in users)
            {
                if (CheckCorrectLoginPassword(login, password))
                {
                    return user.Id;
                }
            }
            return Guid.Empty;
        }
        public static bool IsCheckUserInDB(string login)
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

        public static bool IsCheckEqualTwoPassword(string password, string password2)
        {
            return password==password2;
        }

        public static void AddNewClientInDB(User user,Client client)
        {
            UnitOfWork.Users.Add(user);
            UnitOfWork.Users.Save();
            UnitOfWork.Clients.Add(client);
            UnitOfWork.Clients.Save();
        }
    }
}
