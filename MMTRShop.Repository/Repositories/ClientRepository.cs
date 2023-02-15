using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System.Linq;
using System;
using MMTRShop.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.HelperModels;

namespace MMTRShop.Repository.Repositories
{
    public class ClientRepository : Repository<Client,Guid>, IClientRepository
    {
        public ClientRepository(ShopContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Client>> GetClientsPage(BaseFilter filter)
        {
            var query = ShopContext.Client.AsQueryable();
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
    }
}
