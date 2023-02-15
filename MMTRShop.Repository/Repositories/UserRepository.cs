using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;

namespace MMTRShop.Repository.Repositories
{
    public class UserRepository:Repository<User,Guid>,IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {

        }

        public async Task<IEnumerable<User>> GetUsersPage(BaseFilter filter)
        {
            var query = ShopContext.User.AsQueryable();
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }

    }
}
