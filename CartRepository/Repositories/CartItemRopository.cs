using CartMicroservice.Carts.Repository.Entities;
using CartMicroservice.Carts.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CartMicroservice.Carts.Repository.Repositories
{
    public class CartItemRopository : Repository<CartItem,Guid>, ICartItemRepository
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
            return await Set.Where(c=>c.CartId==cartId).ToListAsync();
        }


    }
}
