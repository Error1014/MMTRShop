using MMTRShop.MiddlewareException.Exceptions;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Windows;

namespace MMTRShop.Service.Services
{
    public class AutorizationService:IAutorizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AutorizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Registration(User user, string password2)
        {
            if (await IsCheckUserInDB(user.Login))
            {
                throw new ValidationException("Пользователь с таким логином уже существует");
            }
            if (!IsCheckEqualTwoPassword(user.Password, password2))
            {
                throw new ValidationException("Пароли должны совпадать!");
            }
            User u = new User(user.Login, user.Password, user.LastName, user.FirstName, user.Patronymic);
            AddNewClientInDB(u);
            return true;
        }
        public async Task<bool> CheckCorrectLoginPassword(string login,string password)
        {
            bool isCorrect = false;
            throw new ValidationException("Вы ввели неверный логин или пароль!");
            var users =await _unitOfWork.Users.GetAllAsync();
            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    isCorrect = true;
                    break;
                }
            }
            return isCorrect;
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
