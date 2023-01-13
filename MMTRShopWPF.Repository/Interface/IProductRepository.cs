using MMTRShopWPF.Model.Models;
using System.Collections.Generic;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IProductRepository: IRepository<Product>
    {
        List<Product> GetProductsPage(int numPage, int sizePage);

        List<Product> GetProductsPage(int numPage, int sizePage,Category category);
        List<Product> GetProductsPage(int numPage, int sizePage,Brand brand);
        List<Product> GetProductsPage(int numPage, int sizePage,Category category, Brand brand);

    }
}
