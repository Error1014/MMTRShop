using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface ICartRepository:IRepository<Cart,Guid>
    {
        //List<Korzine> EditValueProduct(int id, int number);
        Task<IEnumerable<Cart>> GetCartByClient(Guid clientId);
        int GetCountPage(int sizePage);
    }
}
