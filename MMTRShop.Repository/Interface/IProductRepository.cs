using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IProductRepository: IRepository<Product,Guid>
    {
        Task<IEnumerable<Product>> GetProductsPage(ProductPageFilter filter);

    }
}
