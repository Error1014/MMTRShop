using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Windows;

namespace MMTRShopWPF.Service.Services
{
    public class AutorizationService
    {
        private Message Message = new Message();
        private readonly UnitOfWork UnitOfWork;
        public AutorizationService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public Message Registration(User user, string password2)
        {
            if (IsCheckUserInDB(user.Login))
            {
                return Message.GetMessage(true, "Пользователь с таким логином уже существует");
            }
            if (!IsCheckEqualTwoPassword(user.Password, password2))
            {
                return Message.GetMessage(true, "Пароли должны совпадать!");
            }
            User u = new User(user.Login, user.Password, user.LastName, user.FirstName, user.Patronymic);
            AddNewClientInDB(u);
            return Message.GetMessage(false);
        }
        public Message CheckCorrectLoginPassword(string login,string password)
        {
            Message message = new Message(true, "Вы ввели неверный логин или пароль!");
            var users = UnitOfWork.Users.GetAll();
            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    message.VisibilityError = false;
                    break;
                }
            }
            return message;
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

        public void AddNewClientInDB(User user)
        {
            UnitOfWork.Users.Add(user);
            UnitOfWork.Users.Save();
            Client client = new Client(user.Id, "", "", "");
            UnitOfWork.Clients.Add(client);
            UnitOfWork.Clients.Save();
        }
    }
}
