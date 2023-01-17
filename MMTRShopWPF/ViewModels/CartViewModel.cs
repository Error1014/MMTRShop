﻿using MMTRShopWPF.Model;
using MMTRShopWPF.Service.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MMTRShopWPF.View.Pages;
using System;
using MMTRShopWPF.Service;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.ViewModels;

namespace MMTRShopWPF.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private KorzinaPage page;
        private ProductService ProductService = new ProductService();
        private CartService CartService = new CartService();
        public CartViewModel(KorzinaPage page)
        {
            this.page=page;
            Cart = CartService.GetCart();
            Products = ProductService.GetProducts(Cart);
        }
        private List<Cart> cart;
        public List<Cart> Cart
        {
            get
            {
                return cart;
            }
            set
            {
                cart = value;
                OnPropertyChanged(nameof(Cart));
            }
        }

        private List<Product> products;
        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public ICommand ProductMinus
        {
            get
            {
                return new Commands((obj) =>
                {
                    Guid id =  Guid.Parse(obj.ToString());
                    CartService.CartMinusOneProduct(id);
                    page.UpdateDataContext();
                });
            }
        }
        public ICommand ProductPlus
        {
            get
            {
                return new Commands((obj) =>
                {
                    Guid id = Guid.Parse(obj.ToString());
                    CartService.CartPlusOneProduct(id);
                    page.UpdateDataContext();
                });
            }
        }
        public ICommand ProductRemove
        {
            get
            {
                return new Commands((obj) =>
                {
                    Guid id =Guid.Parse(obj.ToString());
                    CartService.CartRemoveProduct(id);
                    page.UpdateDataContext();
                });
            }
        }

        public ICommand OrderCartNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    NavigarionManager.MainFrame.Content = new MakingAnOrderPage();
                });
            }
        }
    }
}
