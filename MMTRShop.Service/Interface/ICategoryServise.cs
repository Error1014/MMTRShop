using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface ICategoryServise
    {
        Task<ObservableCollection<Category>> GetCategories();
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategory(Product product);
        Task<Category> GetCategory(Category category);
        Task SaveChanges(Category category);
        Task Save();
        Task Add(string title);
        Task Remove(Category category);
        Message CheckToRemove(Category category);
    }
}
