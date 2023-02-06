using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class CategoryService: ICategoryServise
    {
        private Message Message = new Message();
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ObservableCollection<Category>> GetCategories()
        {
            var categories =await _unitOfWork.Categories.GetAllAsync();
            return new ObservableCollection<Category>(categories.ToList());
        }
        public async Task<List<Category>> GetAllCategory()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return categories.ToList();
        }

        public async Task<Category> GetCategory(Product product)
        {
            return await _unitOfWork.Categories.FindAsync(category => category.Id == product.CategoryId);
        }
        public async Task<Category> GetCategory(Category category)
        {
            return await _unitOfWork.Categories.FindAsync(c => c.Id == category.Id);
        }

        public async void SaveChanges(Category category)
        {
            if (category == null) return;
            Category categoryDB =await GetCategory(category);
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


        public async void Remove(Category category)
        {
            if (category == null) return;
            _unitOfWork.Categories.Remove(await GetCategory(category));
            Save();
        }

        public Message CheckToRemove(Category category)
        {
            var products = _unitOfWork.Products.FindAsync(c => c.CategoryId == category.Id);
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
