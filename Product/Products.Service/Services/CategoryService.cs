﻿using AutoMapper;
using Products.Repository.Entities;
using Products.Repository.Interfaces;
using Products.Service.Interfaces;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Exceptions;
using Shop.Infrastructure.HelperModels;

namespace Products.Service.Services
{
    public class CategoryService : ICategoryServise
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            _unitOfWork.Categories.Add(category);
            await Save();
        }

        public async Task<CategoryDTO> GetCategory(Guid categoryId)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundException("Категория не найдена");
            }
            var result = _mapper.Map<CategoryDTO>(category);
            return result;
        }

        public async Task<IEnumerable<CategoryDTO>> GetPageCategories(BaseFilter filter)
        {
            var categories = await _unitOfWork.Categories.GetPageElements(filter);
            var result = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return result;
        }

        public async Task Remove(Guid categoryId)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new NotFoundException("Категория не найдена");
            }
            CheckToRemove(categoryId);
            _unitOfWork.Categories.Remove(category);
            await Save();
        }

        public async Task Save()
        {
            await _unitOfWork.Categories.SaveAsync();
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            _unitOfWork.Categories.Update(category);
            await Save();
        }
        public void CheckToRemove(Guid categoryId)
        {
            var task = _unitOfWork.Products.FindAsync(c => c.CategoryId == categoryId);
            var product = task.Result;
            if (product != null)
            {
                throw new ValidationException("Вы не можете удалить данную категорию, так как приведёт к удалению продуктов");
            }
        }
    }
}
