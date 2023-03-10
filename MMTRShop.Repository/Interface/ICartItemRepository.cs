using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface ICartItemRepository:IRepository<CartItem,Guid>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCart(Guid cartId);
        Task ClearCart(Guid cartId);
    }
}
