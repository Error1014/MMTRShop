using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MMTRShop.Repository.Interface
{
    public interface IProductRepository: IRepository<Product,Guid>
    {
        Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage);
        Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage,Category category);
        Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage,Brand brand);
        Task<IEnumerable<Product>> GetProductsPage(int numPage, int sizePage,Category category, Brand brand);

    }
}
