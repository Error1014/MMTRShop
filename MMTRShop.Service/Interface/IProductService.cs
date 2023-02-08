using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IProductService
    {
        Task<Product> GetProduct(Product product);
        Task<Product> GetProduct(Guid id);

        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void Update(Product product);
        void Save();
        void CreateOrUpdateProduct(bool isAdd, Product product);
        void RemoveOrUpdateProduct(bool isAdd, Product product);
        Task<List<Product>> GetProducts(List<Cart> carts);
        Task<List<Product>> GetProducts(List<Favourite> favourites);

        Task<ObservableCollection<Product>> GetPageProducts(int numPage, int sizePage, Guid? categoryId, Guid? brandId);
        int GetCountPage(int sizePage);
        
        void RemoveProductsInStorage(List<Cart> carts);
    }
}
