using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MMTRShopWPF.ViewModels
{
    public class EditProductViewModel: ProductViewModel
    {
        private CategoryService CategoryService = new CategoryService();
        protected BrandService BrandService = new BrandService();
        private ProductService ProductService = new ProductService();
        public EditProductViewModel(Product product)
        {

            if (AccountManager.Admin == null)
            {
                isAdmin = false;
                BlockOpacity = 0.3f;
            }
            else
            {
                isAdmin = true;
                BlockOpacity = 1;
            }
            AllCategory = CategoryService.GetAllCategory();
            AllBrand = BrandService.GetAllBrand();
            SelectCategory = AllCategory[0];
            SelectBrand = AllBrand[0];
            if (product == null)
            {
                isAdd = true;
                Product = new Product();
            }
            else
            {
                isAdd = false;
                SelectCategory = CategoryService.GetCategory(product);
                SelectBrand = BrandService.GetBrandProduct(product);
                Product = ProductService.GetProduct(product);
            }
        }

        private bool isAdd;
        public List<Category> AllCategory { get; private set; }
        private Category selectCategory;
        public Category SelectCategory
        {
            get { return selectCategory; }
            set
            {
                selectCategory = value;
                OnPropertyChanged(nameof(SelectCategory));
            }
        }
        private Product product = new Product();

        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        public List<Brand> AllBrand { get; private set; }
        protected Brand selectBrand;
        public Brand SelectBrand
        {
            get { return selectBrand; }
            set
            {
                selectBrand = value;
                OnPropertyChanged(nameof(SelectBrand));
            }
        }

        public ICommand SaveResult
        {
            get
            {
                return new Commands((obj) =>
                {
                    Product.CategoryId = SelectCategory.Id;
                    Product.BrandId = SelectBrand.Id;
                    if (isAdd)
                    {
                        ProductService.AddProduct(Product);
                        isAdd = false;
                    }
                    ProductService.Save();
                    MessageBox.Show("Успешно");
                    NavigarionManager.MainFrame.Content = new KatalogPage();

                });
            }
        }
        public ICommand Delete
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (!isAdd)
                    {
                        ProductService.RemoveProduct(Product);
                        isAdd = true;
                    }
                    ProductService.Save();
                    MessageBox.Show("Успешно");
                    NavigarionManager.MainFrame.Content = new KatalogPage();
                });
            }
        }
        protected bool isAdmin;
        public bool IsAdmin
        {
            get { return isAdmin; }
            set
            {
                isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        private float blockOpacity;
        public float BlockOpacity
        {
            get { return blockOpacity; }
            set
            {
                blockOpacity = value;
                OnPropertyChanged(nameof(BlockOpacity));
            }
        }
    }
}
