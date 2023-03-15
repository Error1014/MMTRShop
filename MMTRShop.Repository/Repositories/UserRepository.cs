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
        private readonly ShopContext _shopContext;
        private readonly CartContext _cartContext;
        public UserRepository(ShopContext context) : base(context)
        {
            _shopContext = context;
        }
        public UserRepository(CartContext context) : base(context)
        {
            _cartContext = context;
        }

        public async Task<IEnumerable<User>> GetUsersPage(BaseFilter filter)
        {
            var query = _shopContext.User.AsQueryable();
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }

    }
}
