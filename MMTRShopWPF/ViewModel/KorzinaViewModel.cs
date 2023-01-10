using MMTRShopWPF.Service;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MMTRShopWPF.View.Pages;
using System;

namespace MMTRShopWPF.ViewModel
{
    public class KorzinaViewModel : BaseViewModel
    {
        private KorzinaPage page;
        public KorzinaViewModel(User myUser, KorzinaPage page)
        {
            user = myUser;
            this.page = page;
            Cart = UnitOfWork.Carts.GetKorzineByIDUser(user.Id);

            Products = (from k in Cart
                        join p in UnitOfWork.Products.GetAll() on k.ProductId equals p.Id
                        select p).ToList();
        }
        private User user;
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
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
                    System.Guid id = System.Guid.Parse(obj.ToString());
                    var item = UnitOfWork.Carts.GetById(id);
                    if (item.ProductCount>0)
                    {
                        item.ProductCount--;
                    }
                    if (item.ProductCount==0)
                    {
                        UnitOfWork.Carts.Remove(item);
                    }
                    UnitOfWork.Carts.Save();
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
                    System.Guid id = System.Guid.Parse(obj.ToString());
                    var item = UnitOfWork.Carts.GetById(id);
                    item.ProductCount++;

                    UnitOfWork.Carts.Save();
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
                    System.Guid id = System.Guid.Parse(obj.ToString());
                    var item = UnitOfWork.Carts.GetById(id);
                    UnitOfWork.Carts.Remove(item);

                    UnitOfWork.Carts.Save();
                    page.UpdateDataContext();
                });
            }
        }
    }
}
