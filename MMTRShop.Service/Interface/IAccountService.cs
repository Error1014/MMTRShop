using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IAccountService
    {
        Task<User> GetUser();
        Task<Client> GetClient();
        Task Save();
    }
}
