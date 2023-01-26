using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System.Linq;
using System;

namespace MMTRShop.Repository.Repositories
{
    public class ClientRepository : Repository<Client,Guid>, IClientRepository
    {
        public ClientRepository(ShopContext context) : base(context)
        {

        }

    }
}
