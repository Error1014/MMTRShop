using MMTRShop.Model;
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
using System.Windows;

namespace MMTRShop.Service.Services
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProduct(Product product)
        {
            return await _unitOfWork.Products.GetByIdAsync(product.Id);
        }
        public async Task<Product> GetProduct(Guid id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }
        public void AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
        }
        public async void RemoveProduct(Product product)
        {
            Product productDB =await GetProduct(product);
            _unitOfWork.Products.Remove(productDB);
        }
        public void Update(Product product)
        {
            _unitOfWork.Products.Update(product);
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
        public async Task<List<Product>> GetProducts(List<Cart> carts)
        {
            var products = carts.Join(await _unitOfWork.Products.GetAllAsync(),
            k => k.ProductId,
            p => p.Id, (k, p) => new { k, p }).Select(x => x.p).ToList();
            return products;
        }
        public async Task<List<Product>> GetProducts(List<Favourite> favourites)
        {
            var products = favourites.Join(await _unitOfWork.Products.GetAllAsync(),
            f => f.ProductId,
            p => p.Id, (f, p) => new { f, p }).Select(x => x.p).ToList();
            return products;
        }
        
        public async Task<ObservableCollection<Product>> GetPageProducts(int numPage,int sizePage, Guid? categoryId,Guid? brandId)
        {
            var products = await _unitOfWork.Products.GetProductsPage(numPage, sizePage, categoryId, brandId);
            return new ObservableCollection<Product>(products);
        }
        public int GetCountPage(int sizePage)
        {
            return _unitOfWork.Carts.GetCountPage(sizePage);
        }

        public async void RemoveProductsInStorage(List<Cart> carts)
        {
            foreach (var item in carts)
            {
                var product =await _unitOfWork.Products.FindAsync(p => p.Id == item.ProductId);
                product.CountInStarage -= item.ProductCount;
            }
            Save();
        }

    }
}
