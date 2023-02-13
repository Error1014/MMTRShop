using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IAutorizationService
    {
        Task<bool> Registration(User user, string password2);
        Task<bool> CheckCorrectLoginPassword(string login, string password);
        Task<Guid> GetUserId(string login, string password);
        Task<bool> IsCheckUserInDB(string login);

        bool IsCheckEqualTwoPassword(string password, string password2);

        void AddNewClientInDB(User user);
    }
}
