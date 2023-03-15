using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repositories.Repository
{
    public class CartItemRopository : Repository<CartItem,Guid>, ICartItemRepository
    {
        private readonly CartContext _cartContext;
        public CartItemRopository(CartContext context) : base(context)
        {
            _cartContext = context;
        }

        public async Task ClearCart(Guid cartId)
        {
            var cartItem = await GetCartItemsByCart(cartId);
            _cartContext.CartItem.RemoveRange(cartItem);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCart(Guid cartId)
        {
            return await _cartContext.CartItem.Where(c=>c.CartId==cartId).ToListAsync();
        }


    }
}
