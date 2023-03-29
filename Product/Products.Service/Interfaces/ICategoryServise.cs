using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Products.Service.Interfaces
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
