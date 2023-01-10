using MMTRShopWPF.Service;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MMTRShopWPF.View.Pages;

namespace MMTRShopWPF.ViewModel
{
    public class KorzinaViewModel : BaseViewModel
    {
        private KorzinaPage page;
        public KorzinaViewModel(User myUser, KorzinaPage page)
        {
            user = myUser;
            this.page = page;
            Korzine = UnitOfWork.Korzins.GetKorzineByIDUser(user.ID);

            Products = (from k in Korzine
                        join p in UnitOfWork.Products.GetAll() on k.ProductID equals p.ID
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
        private List<Cart> korzine;
        public List<Cart> Korzine
        {
            get
            {
                return korzine;
            }
            set
            {
                korzine = value;
                OnPropertyChanged(nameof(Korzine));
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
                    int id  = int.Parse(obj.ToString());
                    var item = UnitOfWork.Korzins.GetById(id);
                    if (item.ValueProduct>0)
                    {
                        item.ValueProduct--;
                    }
                    if (item.ValueProduct==0)
                    {
                        UnitOfWork.Korzins.Remove(item);
                    }
                    UnitOfWork.Korzins.Save();
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
                    int id = int.Parse(obj.ToString());
                    var item = UnitOfWork.Korzins.GetById(id);
                    item.ValueProduct++;

                    UnitOfWork.Korzins.Save();
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
                    int id = int.Parse(obj.ToString());
                    var item = UnitOfWork.Korzins.GetById(id);
                    UnitOfWork.Korzins.Remove(item);

                    UnitOfWork.Korzins.Save();
                    page.UpdateDataContext();
                });
            }
        }
    }
}
