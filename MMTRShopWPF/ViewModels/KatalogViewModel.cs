using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.Service;
using MMTRShopWPF.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MMTRShopWPF.Service.Services;
using System.Linq;
using MMTRShopWPF.Commands;
using MMTRShopWPF.Repository.Repositories;

namespace MMTRShopWPF.ViewModels
{
    public class KatalogViewModel : BaseViewModel
    {
        private ProductService ProductService = new ProductService(new UnitOfWork(new ShopContext()));

        #region Filtration Category

        private List<Category> сategoryItems;
        public List<Category> CategoryItems
        {
            get 
            {
                if (сategoryItems == null)
                {
                    CategoryItems = UnitOfWork.Categories.GetAll().ToList();
                }
                return сategoryItems; 
            }
            set
            {
                сategoryItems = value;
                OnPropertyChanged(nameof(CategoryItems));
            }
        }
        private Category selectedCategoryItem;
        public Category SelectedCategoryItem
        {
            get { return selectedCategoryItem; }
            set
            {
                selectedCategoryItem = value;
                if (SelectedBrandItem == null)
                {
                    ProductsPage = ProductService.GetPageProducts(NumPage, SizePage, SelectedCategoryItem);
                }
                else
                {
                    ProductsPage = ProductService.GetPageProducts(NumPage, SizePage, SelectedCategoryItem, SelectedBrandItem);
                }
                OnPropertyChanged(nameof(SelectedCategoryItem));
            }
        }
        #endregion

        #region Filtration Brand

        private List<Brand> brandItems;
        public List<Brand> BrandItems
        {
            get 
            {
                if (brandItems==null)
                {
                    BrandItems = UnitOfWork.Brands.GetAll().ToList();
                }
                return brandItems; 
            }
            set
            {
                brandItems = value;
                OnPropertyChanged(nameof(BrandItems));
            }
        }
        private Brand selectedBrandItem;
        public Brand SelectedBrandItem
        {
            get { return selectedBrandItem; }
            set
            {
                selectedBrandItem = value;
                if (SelectedCategoryItem==null)
                {
                    ProductsPage = ProductService.GetPageProducts(NumPage, SizePage, SelectedBrandItem);
                }
                else
                {
                    ProductsPage = ProductService.GetPageProducts(NumPage, SizePage, SelectedCategoryItem, SelectedBrandItem);
                }
                OnPropertyChanged(nameof(SelectedBrandItem));
            }
        }
        #endregion

        #region Pagination

        private int countPage = 0;
        public int CountPage
        {
            get
            {
                if (countPage==0)
                {
                    CountPage = ProductService.GetCountPage(SizePage);
                }
                return countPage;
            }
            set
            {
                countPage = value;
                OnPropertyChanged(nameof(CountPage));
            }
        }
        public int SizePage = 20;
        private int numPage = 1;
        public int NumPage
        {
            get { return numPage; }
            set
            {
                numPage = value;
                OnPropertyChanged(nameof(numPage));
            }
        }
        public int Num1 { get; private set; } = 1;
        public int Num2 { get; private set; } = 2;
        public int Num3 { get; private set; } = 3;
        public int Num4 { get; private set; } = 4;
        public int Num5 { get; private set; } = 5;

        public ICommand PagePlus
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (NumPage < countPage)
                    {
                        NumPage++;
                        SetNumPage(1);
                    }

                    ProductsPage = ProductService.GetPageProducts(numPage,SizePage);
                });
            }
        }
        public ICommand PageMinus
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (NumPage > 1)
                    {
                        NumPage--;
                        SetNumPage(-1);
                    }
                    ProductsPage = ProductService.GetPageProducts(numPage, SizePage);
                });
            }
        }
        private ICommand getProductsPage;
        public ICommand GetProductsPage
        {
            get
            {
                if (getProductsPage == null) getProductsPage = new LoadedKatalogVMCommand(this);
                return getProductsPage;
            }
            
        }

        public void SetNumPage(int value)
        {
            Num1 += value;
            Num2 += value;
            Num3 += value;
            Num4 += value;
            Num5 += value;
            OnPropertyChanged(nameof(Num1));
            OnPropertyChanged(nameof(Num2));
            OnPropertyChanged(nameof(Num3));
            OnPropertyChanged(nameof(Num4));
            OnPropertyChanged(nameof(Num5));
        }
        #endregion
        private ObservableCollection<Product> productsPage;
        public ObservableCollection<Product> ProductsPage
        {
            get
            {
                return productsPage;
            }
            set
            {
                productsPage = value;
                OnPropertyChanged(nameof(ProductsPage));
            }
        }

        private Visibility discountVisible = Visibility.Collapsed;
        public Visibility DiscountVisible
        {
            get { return discountVisible; }
            set
            {
                discountVisible = value;
                OnPropertyChanged(nameof(DiscountVisible));
            }
        }

        public void SelectProduct(object sender)
        {
            var item = ((ListView)sender);
            if (AccountManager.Admin == null&& AccountManager.Operator==null) NavigarionManager.MainFrame.Content = new InfoProductPage((Product)item.SelectedItem);
            else NavigarionManager.MainFrame.Content = new EditInfoProductPage((Product)item.SelectedItem);
        }

        
    }
}
