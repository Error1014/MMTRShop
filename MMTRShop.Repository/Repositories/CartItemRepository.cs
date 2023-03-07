using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Repositories
{
    public class CartItemRepository : Repository<CartItem, Guid>, ICartItemRepository
    {
        private readonly ShopContext _shopContext;
        public CartItemRepository(ShopContext context) : base(context)
        {
            _shopContext = context;
        }
    }
}
