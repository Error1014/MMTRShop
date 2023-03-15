using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using System.Linq;
using System;
using MMTRShop.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MMTRShop.Repository.Repositories
{
    public class ClientRepository : Repository<Client, Guid>, IClientRepository
    {
        private readonly ShopContext _shopContext;
        public ClientRepository(ShopContext context) : base(context)
        {
            _shopContext=context;
        }
        public async Task<IEnumerable<Client>> GetClientsPage(BaseFilter filter)
        {
            var query = Set;
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
    }
}
