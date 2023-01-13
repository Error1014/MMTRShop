using MMTRShopWPF.Model;
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
        public static List<Category> GetAllCategory()
        {
            return UnitOfWork.Categorys.GetAll().ToList();
        }
        public static List<Brand> GetAllBrand()
        {
            return UnitOfWork.Brands.GetAll().ToList();
        }
        public static Category GetCategoryProduct(Guid id)
        {
            return GetAllCategory().Where(category => category.Id == id).FirstOrDefault();
        }
        public static Brand GetBrandProduct(Guid id)
        {
            return GetAllBrand().Where(category => category.Id == id).FirstOrDefault();
        }
        
    }
}
