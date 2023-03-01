using AutoMapper;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Exceptions;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastructure;

namespace MMTRShop.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddUser(UserDTO userDTO)
        {
            var chekUser = await _unitOfWork.Users.FindAsync(u => u.Login == userDTO.Login);
            if (chekUser != null)
            {
                throw new DublicateException("Пользователь с таким логином уже существует");
            }
            var user = _mapper.Map<User>(userDTO);
            _unitOfWork.Users.Add(user);
            await Save();
        }

        public async Task<IEnumerable<UserDTO>> GetPageUser(BaseFilter filter)
        {
            var users = await _unitOfWork.Users.GetUsersPage(filter);
            var result = _mapper.Map<IEnumerable<UserDTO>>(users);
            return result;
        }

        public async Task<UserDTO> GetUser(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("Пользователь не найден");
            }
            var result = _mapper.Map<UserDTO>(user);
            return result;
        }

        public async Task<User> GetUser(LoginPasswordModel loginPassword)
        {
            bool isCorrect = false;
            var users = await _unitOfWork.Users.GetAllAsync();
            User? user = null;
            var password = GeneratorHash.GetHash(loginPassword.Password);
            foreach (var item in users)
            {
                if (item.Login == loginPassword.Login && item.Password == password)
                {
                    isCorrect = true;
                    user = item;
                    break;
                }
            }
            if (isCorrect==false)
            {
                throw new ValidationException("Вы ввели неверный логин или пароль!");
            }
            //var userDTO = _mapper.Map<UserDTO>(user);
            return user;
        }

        public async Task RemoveUser(Guid userId)
        {
            var user = await GetUser(userId);
            _unitOfWork.Users.Remove(userId);
            await Save();
        }

        public async Task Save()
        {
            await _unitOfWork.Users.SaveAsync();
        }

        public async Task Update(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _unitOfWork.Users.Update(user);
            await Save();
        }
    }
}
