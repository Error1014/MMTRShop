using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class CategoryService
    {
        private Message Message = new Message();
        private readonly UnitOfWork _unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ObservableCollection<Category> GetCategories()
        {
            var categories = _unitOfWork.Categories.GetAll();
            return new ObservableCollection<Category>(categories);
        }
        public List<Category> GetAllCategory()
        {
            return _unitOfWork.Categories.GetAll().ToList();
        }

        public Category GetCategory(Product product)
        {
            return _unitOfWork.Categories.Find(category => category.Id == product.CategoryId);
        }
        private Category GetCategory(Category  category)
        {
            return _unitOfWork.Categories.Find(c=>c.Id ==category.Id);
        }
        public void SaveChanges(Category category)
        {
            if (category == null) return;
            Category categoryDB = GetCategory(category);
            categoryDB.Title = category.Title;
            _unitOfWork.Categories.Save();
        }
        public void Save()
        {
            _unitOfWork.Categories.Save();
        }

        public void Add(string title)
        {
            _unitOfWork.Categories.Add(new Category(title));
            Save();
        }


        public void Remove(Category category)
        {
            if (category == null) return;
            _unitOfWork.Categories.Remove(GetCategory(category));
            Save();
        }

        public Message CheckToRemove(Category category)
        {
            var products = _unitOfWork.Products.Find(c => c.CategoryId == category.Id);
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
