using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class CategoryService:BaseService
    {
        public static ObservableCollection<Category> GetCategory()
{
            var categories = UnitOfWork.Categories.GetAll();
            return new ObservableCollection<Category>(categories);
        }
        public static List<Category> GetAllCategory()
        {
            return UnitOfWork.Categories.GetAll().ToList();
        }

        public static Category GetCategory(Product product)
        {
            return GetAllCategory().Where(category => category.Id == product.CategoryId).FirstOrDefault();
        }
        public static void Save()
        {
            UnitOfWork.Categories.Save();
        }
        public static void Create(Category category)
        {
            UnitOfWork.Categories.Add(new Category(category.Title));
            Save();
        }
        public static void Remove(Category category)
        {
            if (!CheckToRemove(category))
            {
                UnitOfWork.Categories.Remove(category);
            }
            Save();
        }

        public static bool CheckToRemove(Category category)
        {
            var products = UnitOfWork.Products.GetAll().Where(c=>c.CategoryId==category.Id).FirstOrDefault();
            return products == null;
        }
    }
}
