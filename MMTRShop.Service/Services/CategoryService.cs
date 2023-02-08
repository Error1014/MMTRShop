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
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return categories;
        }

        public async Task<Category> GetCategory(Guid categoryId)
        {
            return await _unitOfWork.Categories.FindAsync(category => category.Id == categoryId);
        }

        public async Task SaveChanges(Category category)
        {
            if (category == null) return;
            Category categoryDB =await GetCategory(category.Id);
            categoryDB.Title = category.Title;
            await Save();
        }
        public async Task Save()
        {
            await _unitOfWork.Categories.SaveAsync();
        }

        public async Task Add(string title)
        {
            _unitOfWork.Categories.Add(new Category(title));
            await Save();
        }

        public async Task Remove(Category category)
        {
            if (category == null) return;
            _unitOfWork.Categories.Remove(await GetCategory(category.Id));
            await Save();
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
