﻿using Carts.Repository.Entities;
using Shop.Infrastructure.Repository;

namespace Carts.Repository.Interfaces
{
    public interface ICartItemRepository : IRepository<CartItem, Guid>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCart(Guid cartId);
        Task ClearCart(Guid cartId);
    }
}
