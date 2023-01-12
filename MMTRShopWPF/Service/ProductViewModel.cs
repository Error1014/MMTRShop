﻿using MMTRShopWPF.Model;
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
        public ProductVievModel(Product product)
        {
            client = NavigationViewModel.Client;
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
            if (client==null)
            {
                isLikePath = "/Resources/NoLike.png";
            }
            else
            {
                favourit = UnitOfWork.Favorites.GetFavouritByIdUserAndProduct(client.Id, product.Id);
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

        private Client client;


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
        public ICommand ClickLike
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (client==null)
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

        private void ClientNullMessageShow()
        {
            MessageBox.Show("Для этого вам сперва необходимо войти в аккаутн");
            MainWindow.MainWindowFrame.Content = new AutorizationPage();
        }

        private Favourites favourit = new Favourites();
        private void SetLike()
        {
            IsLikePath = "/Resources/Like.png";
            favourit = new Favourites(client.Id, Product.Id);
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
                    if (client == null)
                    {
                        ClientNullMessageShow();
                    }
                    else
                    {
                        var myKorzine = UnitOfWork.Carts.GetKorzineByIDUser(client.Id);
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
                            UnitOfWork.Carts.Add(new Cart(client.Id, Product.Id, 1));
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
