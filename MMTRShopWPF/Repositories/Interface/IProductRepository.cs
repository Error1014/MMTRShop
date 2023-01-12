using MMTRShopWPF.Model;
using System.Collections.Generic;

namespace MMTRShopWPF.Repositories.Interface
{
    public interface IProductRepository: IRepository<Product>
    {
        List<Product> GetProductsPage(int numPage, int sizePage);
      
    }
}
