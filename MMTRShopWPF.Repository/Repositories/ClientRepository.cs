using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System.Linq;
using System;

namespace MMTRShopWPF.Repository.Repositories
{
    public class ClientRepository : Repository<Client,Guid>, IClientRepository
    {
        public ClientRepository(ShopContext context) : base(context)
        {

        }
        public Client GetClientByUser(User user)
        {
            return ShopContext.Client.FirstOrDefault(c => c.UserId == user.Id);
        }
    }
}
