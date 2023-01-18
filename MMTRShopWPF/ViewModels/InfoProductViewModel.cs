using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MMTRShopWPF.View.Pages;

namespace MMTRShopWPF.ViewModels
{
    public class InfoProductViewModel: BaseViewModel
    {
        private int countShow = 4;
        private CartService CartService = new CartService();
        private FavouritesService FavouritesService = new FavouritesService();
        public InfoProductViewModel(Product product)
        {
            if (product != null)
            {
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
        protected string statusProduct;
        public string StatusProduct
        {
            get { return statusProduct; }
            set
            {
                statusProduct = value;
                OnPropertyChanged(nameof(StatusProduct));
            }
        }
        protected Favourites favourit = new Favourites();
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
                    }
                });
            }
        }
        protected string isLikePath;
        public string IsLikePath
        {
            get { return isLikePath; }
            set
            {
                isLikePath = value;
                OnPropertyChanged(nameof(IsLikePath));
            }
        }

        protected void ClientNullMessageShow()
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
        protected Visibility visibilityCount;
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
        protected void SetLike()
        {
            IsLikePath = "/Resources/Like.png";
            favourit = new Favourites(AccountManager.Client.Id, Product.Id);
            FavouritesService.AddFavourite(favourit);

        }
        protected void RemoveLike()
        {
            IsLikePath = "/Resources/NoLike.png";
            FavouritesService.RemoveFavourite(favourit);
            favourit = new Favourites();
        }
    }
}
