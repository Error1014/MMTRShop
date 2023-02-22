using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface ICartRepository:IRepository<Cart,Guid>
    {
        //List<Korzine> EditValueProduct(int id, int number);
        Task<IEnumerable<Cart>> GetCartsByClient(Guid clientId);
        Task<Cart> GetCartByClientIdAndProductId(Guid clientId,Guid productId);
        Task<IEnumerable<Cart>> GetCarts(FilterByClient filter);
        int GetCountPage(int sizePage);
    }
}
