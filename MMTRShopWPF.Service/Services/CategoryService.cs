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
        public static void Save()
        {
            UnitOfWork.Categories.Save();
        }
        public static void Create(string title)
        {
            UnitOfWork.Categories.Add(new Category(title));
            Save();
        }
        public static void Remove(Category category)
        {
            UnitOfWork.Categories.Remove(category);
            Save();
        }
    }
}
