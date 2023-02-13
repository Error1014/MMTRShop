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
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategory(Guid categoryId);
        Task SaveChanges(Category category);
        Task Save();
        Task Add(string title);
        Task Remove(Category category);
        bool CheckToRemove(Category category);
    }
}
