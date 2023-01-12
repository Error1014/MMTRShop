using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories;
using MMTRShopWPF.View.Pages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MMTRShopWPF.Service
{
    public class KatalogViewModel : BaseViewModel
    {
        public KatalogViewModel()
        {

            productsPage = GetPageProduct();
            if (ShopContext.GetContext().Product.Count() % SizePage == 0)
            {
                valuePage = ShopContext.GetContext().Product.Count() / SizePage;
            }
            else
            {
                valuePage = ShopContext.GetContext().Product.Count() / SizePage + 1;
            }
            var categories = UnitOfWork.Categorys.GetAll();
            var brands = UnitOfWork.Brands.GetAll();
            CategoryItems = new ObservableCollection<Category>(categories);
            BrandItems = new ObservableCollection<Brand>(brands);
        }

        #region Filtration Category

        private ObservableCollection<Category> сategoryItems;
        public ObservableCollection<Category> CategoryItems
        {
            get { return сategoryItems; }
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
                ProductsPage = UnitOfWork.Products.GetProductsPage(NumPage, SizePage,SelectedCategoryItem);
                OnPropertyChanged(nameof(SelectedCategoryItem));
            }
        }
        #endregion

        #region Filtration Brand

        private ObservableCollection<Brand> brandItems;
        public ObservableCollection<Brand> BrandItems
        {
            get { return brandItems; }
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
                ProductsPage = UnitOfWork.Products.GetProductsPage(NumPage, SizePage, SelectedBrandItem);
                OnPropertyChanged(nameof(SelectedBrandItem));
            }
        }
        #endregion

        #region Pagination

        private int valuePage = 0;
        private int numPage = 1;
        private int SizePage = 20;
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
                    if (NumPage < valuePage)
                    {
                        NumPage++;
                        SetNumPage(1);
                    }

                    ProductsPage = GetPageProduct();
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
                    ProductsPage = GetPageProduct();
                });
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

        public List<Product> GetPageProduct()
        {
            return UnitOfWork.Products.GetProductsPage(NumPage, SizePage);
        }

        private List<Product> productsPage;
        public List<Product> ProductsPage
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
            if (AccountManager.Admin == null) NavigarionManager.MainFrame.Content = new InfoProductPage((Product)item.SelectedItem);
            else NavigarionManager.MainFrame.Content = new EditInfoProductPage((Product)item.SelectedItem);
        }

        
    }
}
