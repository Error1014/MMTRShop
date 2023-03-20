using Carts.Repository.Entities;
using Carts.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Repository;

namespace Carts.Repository.Repositories
{
    public class CartItemRopository : Repository<CartItem, Guid>, ICartItemRepository
    {
        private readonly CartContext _cartContext;
        public CartItemRopository(DbContext context) : base(context)
        {
        }

        public async Task ClearCart(Guid cartId)
        {
            var cartItem = await GetCartItemsByCart(cartId);
            _cartContext.CartItem.RemoveRange(cartItem);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCart(Guid cartId)
        {
            return await Set.Where(c => c.CartId == cartId).ToListAsync();
        }


    }
}
