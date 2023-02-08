using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IProductRepository: IRepository<Product,Guid>
    {
        Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage, Guid? categoryId, Guid? brandId);

    }
}
