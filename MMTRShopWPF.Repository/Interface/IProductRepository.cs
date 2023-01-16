using MMTRShopWPF.Model.Models;
using System.Collections.Generic;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IProductRepository: IRepository<Product>
    {
        IEnumerable<Product> GetProductsPage(int numPage, int sizePage);

        IEnumerable<Product> GetProductsPage(int numPage, int sizePage,Category category);
        IEnumerable<Product> GetProductsPage(int numPage, int sizePage,Brand brand);
        IEnumerable<Product> GetProductsPage(int numPage, int sizePage,Category category, Brand brand);

    }
}
