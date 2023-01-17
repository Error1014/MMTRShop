using MMTRShopWPF.Model.Models;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.Service;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class ProductVievModel : BaseViewModel
    {
        private bool isAdd;
        private int countShow = 4;
        private ProductService ProductService  = new ProductService();
        private CategoryService CategoryService = new CategoryService();
        private CartService CartService = new CartService();
        private BrandService BrandService = new BrandService();
        private FavouritesService FavouritesService = new FavouritesService();


        public ProductVievModel(Product product)
        {
            if (AccountManager.Admin==null)
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
            AllBrand = UnitOfWork.Brands.GetAll().ToList();
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
                Product = product;
            }

            if (Product.CountInStarage < countShow)
            {
                if (Product.CountInStarage == 0)
                {
                    StatusProduct = "Закончился";
                    VisibilityCount = Visibility.Collapsed;
                }
                else
                {
                    StatusProduct = "Доступен";
                    VisibilityCount = Visibility.Visible;
                }
            }
            else
            {
                StatusProduct = "Доступен";
                VisibilityCount = Visibility.Collapsed;
            }
            if (AccountManager.Client == null)
            {
                isLikePath = "/Resources/NoLike.png";
            }
            else
            {
                favourit = FavouritesService.GetFavourit(product);
                if (favourit == null)
                {
                    isLikePath = "/Resources/NoLike.png";
                }
                else
                {
                    isLikePath = "/Resources/Like.png";
                }
            }


        }
        private string statusProduct;
        public string StatusProduct
        {
            get { return statusProduct; }
            set
            {
                statusProduct = value;
                OnPropertyChanged(nameof(StatusProduct));
            }
        }
        private Favourites favourit = new Favourites();

        private Product product;

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

        private string isLikePath;
        public string IsLikePath
        {
            get { return isLikePath; }
            set
            {
                isLikePath = value;
                OnPropertyChanged(nameof(IsLikePath));
            }
        }

        private void ClientNullMessageShow()
        {
            MessageBox.Show("Для этого вам сперва необходимо войти в аккаутн");
            MainWindow.MainWindowFrame.Content = new AutorizationPage();
        }
        public ICommand ClickLike
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (AccountManager.Client == null)
                    {
                        ClientNullMessageShow();
                    }
                    else
                    {
                        if (IsLikePath == "/Resources/NoLike.png")
                        {
                            SetLike();
                        }
                        else
                        {
                            RemoveLike();
                        }
                    }

                });
            }
        }
        private Visibility visibilityCount;
        public Visibility VisibilityCount
        {
            get
            {
                return visibilityCount;
            }
            set
            {
                visibilityCount = value;
                OnPropertyChanged(nameof(VisibilityCount));
            }
        }
        private void SetLike()
        {
            IsLikePath = "/Resources/Like.png";
            favourit = new Favourites(AccountManager.Client.Id, Product.Id);
            FavouritesService.AddFavourite(favourit);

        }
        private void RemoveLike()
        {
            IsLikePath = "/Resources/NoLike.png";
            FavouritesService.RemoveFavourite(favourit);
            favourit = new Favourites();
        }

        public ICommand AddInKorzine
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (AccountManager.Client == null)
                    {
                        ClientNullMessageShow();
                    }
                    else
                    {
                        CartService.AddProductInCart(Product);
                        MessageBox.Show("Успешно");
                    }
                });
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

        public List<Brand> AllBrand { get; private set; }
        private Brand selectBrand;
        public Brand SelectBrand
        {
            get { return selectBrand; }
            set
            {
                selectBrand = value;
                OnPropertyChanged(nameof(SelectBrand));
            }
        }

        private bool isAdmin;
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
