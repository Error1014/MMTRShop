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
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var result = await _unitOfWork.Products.GetByIdAsync(id);
            if (result == null)
            {
                throw new NotFoundException("Товар не найден");
            }
            return result;
        }
        public void AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            Save();
        }
        public async Task RemoveProduct(Product product)
        {
            Product? productDB = await GetProduct(product.Id);
            _unitOfWork.Products.Remove(productDB);
            Save();
        }
        public void Update(Product product)
        {
            _unitOfWork.Products.Update(product);
            Save();
        }
        public void Save()
        {
            _unitOfWork.Products.Save();
        }
        public void CreateOrUpdateProduct(bool isAdd, Product product)
        {
            if (isAdd)
            {
                AddProduct(product);
            }
            Save();
        }
        public void RemoveOrUpdateProduct(bool isAdd, Product product)
        {
            if (!isAdd)
            {
                RemoveProduct(product);
            }
            Save();
        }

        public async Task<IEnumerable<Product>> GetPageProducts(ProductPageFilter filter)
        {
            return await _unitOfWork.Products.GetProductsPage(filter);
        }


    }
}
