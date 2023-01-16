using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShopWPF.Repository.Interface
{
    public interface ICartRepository:IRepository<Cart,Guid>
    {
        //List<Korzine> EditValueProduct(int id, int number);
        IEnumerable<Cart> GetCartByClient(Client client);
        int GetCountPage(int sizePage);
    }
}
