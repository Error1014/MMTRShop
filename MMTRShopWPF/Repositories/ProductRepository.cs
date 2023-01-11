using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositoryes
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public List<Product> GetProductsPage(int numPage, int sizePage)
        {
            return ShopContext.Product.OrderBy(product=> product.Id).Skip((numPage-1)*sizePage).Take(sizePage).ToList();
        }
    }
}
