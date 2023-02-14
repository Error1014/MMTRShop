using Microsoft.AspNetCore.Mvc;
using MMTRShop.Model.HelperModels;
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
        Task<Product> GetProduct(Guid id);

        void AddProduct(Product product);
        Task RemoveProduct(Product product);
        void Update(Product product);
        void Save();
        void CreateOrUpdateProduct(bool isAdd, Product product);
        void RemoveOrUpdateProduct(bool isAdd, Product product);
        Task<List<Product>> GetProductsByCart(List<Cart> carts);
        Task<List<Product>> GetProductsByFavourite(List<Favourite> favourites);

        Task<ObservableCollection<Product>> GetPageProducts(ProductPageFilter filter);
        int GetCountPage(int sizePage);
        
        void RemoveProductsInStorage(List<Cart> carts);
    }
}
