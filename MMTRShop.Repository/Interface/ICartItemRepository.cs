using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface ICartItemRepository:IRepository<CartItem,Guid>
    {
        //List<Korzine> EditValueProduct(int id, int number);
        Task<IEnumerable<CartItem>> GetCartsByClient(Guid clientId);
        Task<CartItem> GetCartByClientIdAndProductId(Guid clientId,Guid productId);
        Task<IEnumerable<CartItem>> GetCarts(FilterByClient filter);
        int GetCountPage(int sizePage);
    }
}
