using MMTRShopWPF.Model;
using MMTRShopWPF.View.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.Service
{
    public class ProductVievModel : BaseViewModel
    {
        private bool isAdd;
        private int countShow = 4;
        public ProductVievModel(Product product)
        {
            AllCategory = UnitOfWork.Categorys.GetAll().ToList();
            AllBrand = UnitOfWork.Brands.GetAll().ToList();
            if (product == null)
            {
                isAdd = true;
                SelectCategory = AllCategory.FirstOrDefault();
                SelectBrand = AllBrand.FirstOrDefault();
                Product = new Product();
            }
            else
            {
                isAdd = false;
                SelectCategory = AllCategory.Where(category => category.Id == product.CategoryId).First();
                SelectBrand = AllBrand.Where(brand => brand.Id == product.BrandId).First();
                Product = UnitOfWork.Products.GetById(product.Id);
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
                favourit = UnitOfWork.Favorites.GetFavouritByIdClientAndProduct(AccountManager.Client.Id, product.Id);
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
            UnitOfWork.Favorites.Add(favourit);
            UnitOfWork.Favorites.Save();

        }
        private void RemoveLike()
        {
            IsLikePath = "/Resources/NoLike.png";
            UnitOfWork.Favorites.Remove(favourit);
            UnitOfWork.Favorites.Save();
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
                        var myKorzine = UnitOfWork.Carts.GetCartByIdClient(AccountManager.Client.Id);
                        bool isNew = true;
                        for (int i = 0; i < myKorzine.Count; i++)
                        {
                            if (myKorzine[i].ProductId == Product.Id)
                            {
                                isNew = false;
                                myKorzine[i].ProductCount++;
                            }
                        }
                        if (isNew)
                        {
                            UnitOfWork.Carts.Add(new Cart(AccountManager.Client.Id, Product.Id, 1));
                        }
                        UnitOfWork.Carts.Save();
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
                    product.CategoryId = SelectCategory.Id;
                    product.BrandId = SelectBrand.Id;
                    if (isAdd)
                    {
                        UnitOfWork.Products.Add(Product);
                        isAdd = false;
                    }
                    UnitOfWork.Products.Save();
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
                        UnitOfWork.Products.Remove(Product);
                        isAdd = true;
                    }
                    UnitOfWork.Products.Save();
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
    }
}
