using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IProductRepository: IRepository<Product,Guid>
    {
        IEnumerable<Product> GetProductsPage(int numPage, int sizePage);

        IEnumerable<Product> GetProductsPage(int numPage, int sizePage,Category category);
        IEnumerable<Product> GetProductsPage(int numPage, int sizePage,Brand brand);
        IEnumerable<Product> GetProductsPage(int numPage, int sizePage,Category category, Brand brand);

    }
}
