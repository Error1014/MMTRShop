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
        Product GetProduct(Product product);
        Product GetProduct(Guid id);

        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void Save();
        void SeveResultEdit(bool isAdd, Product product);
        void RemoveResultEdit(bool isAdd, Product product);
        List<Product> GetProducts(List<Cart> carts);
        List<Product> GetProducts(List<Favourites> favourites);

        ObservableCollection<Product> GetPageProducts(int numPage, int sizePage);
        ObservableCollection<Product> GetPageProducts(int numPage, int sizePage, Category category);
        ObservableCollection<Product> GetPageProducts(int numPage, int sizePage, Brand brand);
        ObservableCollection<Product> GetPageProducts(int numPage, int sizePage, Category category, Brand brand);
        int GetCountPage(int sizePage);
        
        void RemoveProductsInStorage(List<Cart> carts);
    }
}
