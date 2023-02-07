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
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }
        public async Task<Product> GetProduct(Product product)
        {
            return await _unitOfWork.Products.GetByIdAsync(product.Id);
        }
        public async Task<Product> GetProduct(Guid id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }
        public async Task AddProduct(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
        }
        public async Task RemoveProduct(Product product)
        {
            Product productDB = await GetProduct(product);
            _unitOfWork.Products.Remove(productDB);
        }
        public async Task Save()
        {
             await _unitOfWork.Products.SaveAsync();
        }
        public async Task CreateOrUpdateProduct(bool isAdd, Product product)
        {
            if (isAdd)
            {
                AddProduct(product);
            }

            await Save();
        }
        public async Task RemoveOrUpdateProduct(bool isAdd, Product product)
        {
            if (!isAdd)
            {
                RemoveProduct(product);
            }
            await Save();
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

        public async Task<ObservableCollection<Product>> GetPageProducts(int numPage,int sizePage)
        {
            var products = await _unitOfWork.Products.GetProductsPage(numPage, sizePage);
            return new ObservableCollection<Product>(products);
        }
        public async Task<ObservableCollection<Product>> GetPageProducts(int numPage, int sizePage, Category category)
        {
            var products =await _unitOfWork.Products.GetProductsPage(numPage, sizePage,category);
            return new ObservableCollection<Product>(products);
        }
        public async Task<ObservableCollection<Product>> GetPageProducts(int numPage, int sizePage, Brand brand)
        {
            var products =await _unitOfWork.Products.GetProductsPage(numPage, sizePage,brand);
            return new ObservableCollection<Product>(products);
        }
        public async Task<ObservableCollection<Product>> GetPageProducts(int numPage, int sizePage, Category category, Brand brand)
        {
            var products =await _unitOfWork.Products.GetProductsPage(numPage, sizePage, category,brand);
            return new ObservableCollection<Product>(products);
        }
        public int GetCountPage(int sizePage)
        {
            return _unitOfWork.Carts.GetCountPage(sizePage);
        }

        public async Task RemoveProductsInStorage(List<Cart> carts)
        {
            foreach (var item in carts)
            {
                var product =await _unitOfWork.Products.FindAsync(p => p.Id == item.ProductId);
                product.CountInStarage -= item.ProductCount;
            }
            await Save();
        }

    }
}
