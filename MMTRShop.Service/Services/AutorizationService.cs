using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Windows;

namespace MMTRShop.Service.Services
{
    public class AutorizationService:IAutorizationService
    {
        private Message Message = new Message();
        private readonly UnitOfWork _unitOfWork;
        public AutorizationService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Message> Registration(User user, string password2)
        {
            if (await IsCheckUserInDB(user.Login))
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
        public async Task<Message> CheckCorrectLoginPassword(string login,string password)
        {
            Message message = new Message(true, "Вы ввели неверный логин или пароль!");
            var users =await _unitOfWork.Users.GetAllAsync();
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

        public async Task<Guid> GetUserId(string login, string password)
        {
            var users =await _unitOfWork.Users.GetAllAsync();
            foreach (var user in users)
            {
                if (login==user.Login && password==user.Password)
                {
                    return user.Id;
                }
            }
            return Guid.Empty;
        }
        public async Task<bool> IsCheckUserInDB(string login)
        {
            var users =await _unitOfWork.Users.GetAllAsync();
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
            _unitOfWork.Users.Add(user);
            _unitOfWork.Users.Save();
            Client client = new Client(user.Id, "", "", "");
            _unitOfWork.Clients.Add(client);
            _unitOfWork.Clients.Save();
        }
    }
}
