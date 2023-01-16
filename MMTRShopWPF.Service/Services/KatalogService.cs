using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MMTRShopWPF.Service.Services
{
    public class KatalogService:BaseService
    {
        public static List<Product> GetPageProducts(int numPage,int sizePage)
        {
            return UnitOfWork.Products.GetProductsPage(numPage, sizePage);
        }
        public static List<Product> GetPageProducts(int numPage, int sizePage, Category category)
        {
            return UnitOfWork.Products.GetProductsPage(numPage, sizePage,category);
        }
        public static List<Product> GetPageProducts(int numPage, int sizePage, Brand brand)
        {
            return UnitOfWork.Products.GetProductsPage(numPage, sizePage,brand);
        }
        public static List<Product> GetPageProducts(int numPage, int sizePage, Category category, Brand brand)
        {
            return UnitOfWork.Products.GetProductsPage(numPage, sizePage, category,brand);
        }
        public static int GetCountPage(int sizePage)
        {
            return UnitOfWork.Carts.GetCountPage(sizePage);
        }
    }
}
