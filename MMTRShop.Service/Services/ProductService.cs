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

        public async Task<ProductDTO> GetProduct(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException("Товар не найден");
            }
            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }
        public void AddProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Add(product);
            Save();
        }
        public async Task RemoveProduct(Guid productId)
        {
           _unitOfWork.Products.Remove(productId);
           await _unitOfWork.Products.SaveAsync();
        }
        public void Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Update(product);
            Save();
        }
        public void Save()
        {
            _unitOfWork.Products.Save();
        }

        public async Task<IEnumerable<ProductDTO>> GetPageProducts(ProductPageFilter filter)
        {
            var products = await _unitOfWork.Products.GetProductsPage(filter);
            var result = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return result;
        }


    }
}
