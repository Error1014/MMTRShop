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
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProduct(Product product);
        Task<Product> GetProduct(Guid id);

        Task AddProduct(Product product);
        Task RemoveProduct(Product product);
        Task Save();
        Task CreateOrUpdateProduct(bool isAdd, Product product);
        Task RemoveOrUpdateProduct(bool isAdd, Product product);
        Task<List<Product>> GetProducts(List<Cart> carts);
        Task<List<Product>> GetProducts(List<Favourite> favourites);

        Task<ObservableCollection<Product>> GetPageProducts(int numPage, int sizePage);
        Task<ObservableCollection<Product>> GetPageProducts(int numPage, int sizePage, Category category);
        Task<ObservableCollection<Product>> GetPageProducts(int numPage, int sizePage, Brand brand);
        Task<ObservableCollection<Product>> GetPageProducts(int numPage, int sizePage, Category category, Brand brand);
        int GetCountPage(int sizePage);
        
        Task RemoveProductsInStorage(List<Cart> carts);
    }
}
