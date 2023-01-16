using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class ProductService: BaseService
    {
        public static void AddProduct(Product product)
        {
            UnitOfWork.Products.Add(product);
        }
        public static void RemoveProduct(Product product)
        {
            UnitOfWork.Products.Remove(product);
        }
        public static void Save()
        {
            UnitOfWork.Products.Save();
        }
        public static List<Product> GetProducts(List<Cart> carts)
        {
            var products = carts.Join(UnitOfWork.Products.GetAll(),
            k => k.ProductId,
            p => p.Id, (k, p) => new { k, p }).Select(x => x.p).ToList();
            return products;
        }
        public static List<Product> GetProducts(List<Favourites> favourites)
        {
            var products = favourites.Join(UnitOfWork.Products.GetAll(),
            f => f.ProductId,
            p => p.Id, (f, p) => new { f, p }).Select(x => x.p).ToList();
            return products;
        }

        public static List<Product> GetPageProducts(int numPage, int sizePage)
        {
            return UnitOfWork.Products.GetProductsPage(numPage, sizePage);
        }
        public static List<Product> GetPageProducts(int numPage, int sizePage, Category category)
        {
            return UnitOfWork.Products.GetProductsPage(numPage, sizePage, category);
        }
        public static List<Product> GetPageProducts(int numPage, int sizePage, Brand brand)
        {
            return UnitOfWork.Products.GetProductsPage(numPage, sizePage, brand);
        }
        public static List<Product> GetPageProducts(int numPage, int sizePage, Category category, Brand brand)
        {
            return UnitOfWork.Products.GetProductsPage(numPage, sizePage, category, brand);
        }
        public static int GetCountPage(int sizePage)
        {
            return UnitOfWork.Carts.GetCountPage(sizePage);
        }

    }
}
