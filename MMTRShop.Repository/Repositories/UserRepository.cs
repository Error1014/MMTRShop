using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
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
            //var query = ShopContext.User.AsQueryable();
            //query = query
            //    .OrderBy(x => x.Id)
            //    .Skip((filter.NumPage - 1) * filter.SizePage)
            //    .Take(filter.SizePage);
            return null;// await query.ToListAsync();
        }

    }
}
