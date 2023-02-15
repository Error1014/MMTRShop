using AutoMapper;
using MMTRShop.DTO.DTO;
using MMTRShop.MiddlewareException;
using MMTRShop.MiddlewareException.Exceptions;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Service.Interface;
using System.Collections.ObjectModel;

namespace MMTRShop.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetProduct(Guid productId)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
            {
                throw new NotFoundException("Товар не найден");
            }
            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }
        public async Task AddProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Add(product);
            await Save();
        }
        public async Task RemoveProduct(Guid productId)
        {
            var product = await GetProduct(productId);
            _unitOfWork.Products.Remove(productId);
            await Save();
        }
        public async Task Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Update(product);
            await Save();
        }
        public async Task Save()
        {
            await _unitOfWork.Products.SaveAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetPageProducts(ProductPageFilter filter)
        {
            var products = await _unitOfWork.Products.GetProductsPage(filter);
            var result = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return result;
        }


    }
}
