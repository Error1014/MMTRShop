using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShopWPF.Service.Services
{
    public class ProductService
    {
        private readonly UnitOfWork UnitOfWork;
        public ProductService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public Product GetProduct(Product product)
        {
            return UnitOfWork.Products.Find(p=>p.Id == product.Id);
        }
        public void AddProduct(Product product)
        {
            UnitOfWork.Products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            Product productDB = GetProduct(product);
            UnitOfWork.Products.Remove(productDB);
        }
        public void Save()
        {
            UnitOfWork.Products.Save();
        }
        public void SeveResultEdit(bool isAdd, Product product)
        {
            if (isAdd)
            {
                AddProduct(product);
            }
            else
            {
                Product productDB = GetProduct(product);
                //Исправить так чтобы сохранялись изменения
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
            var products = carts.Join(UnitOfWork.Products.GetAll(),
            k => k.ProductId,
            p => p.Id, (k, p) => new { k, p }).Select(x => x.p).ToList();
            return products;
        }
        public List<Product> GetProducts(List<Favourites> favourites)
        {
            var products = favourites.Join(UnitOfWork.Products.GetAll(),
            f => f.ProductId,
            p => p.Id, (f, p) => new { f, p }).Select(x => x.p).ToList();
            return products;
        }

        public ObservableCollection<Product> GetPageProducts(int numPage,int sizePage)
        {
            var products = UnitOfWork.Products.GetProductsPage(numPage, sizePage).ToList();
            return new ObservableCollection<Product>(products);
        }
        public ObservableCollection<Product> GetPageProducts(int numPage, int sizePage, Category category)
        {
            var products = UnitOfWork.Products.GetProductsPage(numPage, sizePage,category).ToList();
            return new ObservableCollection<Product>(products);
        }
        public ObservableCollection<Product> GetPageProducts(int numPage, int sizePage, Brand brand)
        {
            var products = UnitOfWork.Products.GetProductsPage(numPage, sizePage,brand).ToList();
            return new ObservableCollection<Product>(products);
        }
        public ObservableCollection<Product> GetPageProducts(int numPage, int sizePage, Category category, Brand brand)
        {
            var products = UnitOfWork.Products.GetProductsPage(numPage, sizePage, category,brand).ToList();
            return new ObservableCollection<Product>(products);
        }
        public int GetCountPage(int sizePage)
        {
            return UnitOfWork.Carts.GetCountPage(sizePage);
        }

    }
}
