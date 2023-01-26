using MMTRShop.Model;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShop.Service.Services
{
    public class ProductService
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Product GetProduct(Product product)
        {
            return _unitOfWork.Products.Find(p=>p.Id == product.Id);
        }
        public void AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            Product productDB = GetProduct(product);
            _unitOfWork.Products.Remove(productDB);
        }
        public void Save()
        {
            _unitOfWork.Products.Save();
        }
        public void SeveResultEdit(bool isAdd, Product product)
        {
            if (isAdd)
            {
                AddProduct(product);
            }

            Save();
        }
        public void RemoveResultEdit(bool isAdd, Product product)
        {
            if (!isAdd)
            {
                RemoveProduct(product);
            }
            Save();
        }
        public List<Product> GetProducts(List<Cart> carts)
        {
            var products = carts.Join(_unitOfWork.Products.GetAll(),
            k => k.ProductId,
            p => p.Id, (k, p) => new { k, p }).Select(x => x.p).ToList();
            return products;
        }
        public List<Product> GetProducts(List<Favourites> favourites)
        {
            var products = favourites.Join(_unitOfWork.Products.GetAll(),
            f => f.ProductId,
            p => p.Id, (f, p) => new { f, p }).Select(x => x.p).ToList();
            return products;
        }

        public ObservableCollection<Product> GetPageProducts(int numPage,int sizePage)
        {
            var products = _unitOfWork.Products.GetProductsPage(numPage, sizePage).ToList();
            return new ObservableCollection<Product>(products);
        }
        public ObservableCollection<Product> GetPageProducts(int numPage, int sizePage, Category category)
        {
            var products = _unitOfWork.Products.GetProductsPage(numPage, sizePage,category).ToList();
            return new ObservableCollection<Product>(products);
        }
        public ObservableCollection<Product> GetPageProducts(int numPage, int sizePage, Brand brand)
        {
            var products = _unitOfWork.Products.GetProductsPage(numPage, sizePage,brand).ToList();
            return new ObservableCollection<Product>(products);
        }
        public ObservableCollection<Product> GetPageProducts(int numPage, int sizePage, Category category, Brand brand)
        {
            var products = _unitOfWork.Products.GetProductsPage(numPage, sizePage, category,brand).ToList();
            return new ObservableCollection<Product>(products);
        }
        public int GetCountPage(int sizePage)
        {
            return _unitOfWork.Carts.GetCountPage(sizePage);
        }

        public void RemoveProductsInStorage(List<Cart> carts)
        {
            foreach (var item in carts)
            {
                var product = _unitOfWork.Products.Find(p => p.Id == item.ProductId);
                product.CountInStarage -= item.ProductCount;
            }
            Save();
        }

    }
}
