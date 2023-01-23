using MMTRShopWPF.Model;
using MMTRShopWPF.Service.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MMTRShopWPF.View.Pages;
using System;
using MMTRShopWPF.Service;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.ViewModels;
using MMTRShopWPF.Commands;

namespace MMTRShopWPF.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private KorzinaPage page;
        private CartService CartService = new CartService();
        public CartViewModel(KorzinaPage page)
        {
            this.page=page;
            Cart = CartService.GetCart();
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
        private ICommand productMinus;
        public ICommand ProductMinus
        {
            get
            {
                productMinus = new CartProductMinusCommand(this);
                return productMinus;
            }
        }
        private ICommand productPlus;
        public ICommand ProductPlus
        {
            get
            {
                productPlus = new CartProductPlusCommand(this);
                return productPlus;
            }
        }
        private ICommand productRemove;
        public ICommand ProductRemove
        {
            get
            {
                productRemove = new CartProductRemoveCommand(this);
                return productRemove;
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
