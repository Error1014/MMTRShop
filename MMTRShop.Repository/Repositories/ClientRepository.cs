using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System.Linq;
using System;
using MMTRShop.Repository.Contexts;

namespace MMTRShop.Repository.Repositories
{
    public class ClientRepository : Repository<Client,Guid>, IClientRepository
    {
        public ClientRepository(ShopContext context) : base(context)
        {

        }

    }
}
