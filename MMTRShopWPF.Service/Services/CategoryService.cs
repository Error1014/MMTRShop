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
        private Message Message = new Message();
        private readonly UnitOfWork UnitOfWork;
        public CategoryService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public ObservableCollection<Category> GetCategories()
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
        public void Save(object obj)
        {
            UnitOfWork.Categories.Save();
        }
        public void Add(object obj)
        {
            UnitOfWork.Categories.Add(new Category(obj.ToString()));
            Save();
        }
        public void Add(Category category)
        {
            UnitOfWork.Categories.Add(new Category(category.Title));
            Save();
        }
        public void Remove(object obj)
        {
            var categ = obj as Category;
            Category category = UnitOfWork.Categories.Find(c=>c.Id == categ.Id);
            UnitOfWork.Categories.Remove(category);
            Save();
        }
        public void Remove(Category category)
        {
            UnitOfWork.Categories.Remove(category);
            Save();
        }

        public Message CheckToRemove(Category category)
        {
            var products = UnitOfWork.Products.Find(c => c.CategoryId == category.Id);
            if (products==null)
            {
                return new Message(false);
            }
            else
            {
                return Message.GetMessage(true, "Вы не можете удалить данную категорию, так как приведёт к удалению продуктов");
            }
        }
    }
}
