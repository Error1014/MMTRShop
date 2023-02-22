using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
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
        Task<IEnumerable<CategoryDTO>> GetPageCategories(BaseFilter filter);
        Task<CategoryDTO> GetCategory(Guid categoryId);
        Task Update(CategoryDTO category);
        Task Save();
        Task AddCategory(CategoryDTO category);
        Task Remove(Guid categoryId);
        void CheckToRemove(Guid categoryId);
    }
}
