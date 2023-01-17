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
    public class CategoryService
    {
        UnitOfWork UnitOfWork { get; set; }
        public CategoryService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public ObservableCollection<Category> GetCategory()
{
            var categories = UnitOfWork.Categories.GetAll();
            return new ObservableCollection<Category>(categories);
        }
        public List<Category> GetAllCategory()
        {
            return UnitOfWork.Categories.GetAll().ToList();
        }

        public Category GetCategory(Product product)
        {
            return UnitOfWork.Categories.Find(category => category.Id == product.CategoryId);
        }
        public void Save()
        {
            UnitOfWork.Categories.Save();
        }
        public void Create(Category category)
        {
            UnitOfWork.Categories.Add(new Category(category.Title));
            Save();
        }
        public void Remove(Category category)
        {
            if (!CheckToRemove(category))
            {
                UnitOfWork.Categories.Remove(category);
            }
            Save();
        }

        public bool CheckToRemove(Category category)
        {
            var products = UnitOfWork.Products.Find(c=>c.CategoryId==category.Id);
            return products == null;
        }
    }
}
