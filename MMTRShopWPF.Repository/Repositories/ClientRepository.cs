using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System.Linq;
using System;

namespace MMTRShopWPF.Repository.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public Client GetClientByUserId(Guid id)
        {
            return ShopContext.Client.Where(c => c.UserId == id).FirstOrDefault();
        }
    }
}
