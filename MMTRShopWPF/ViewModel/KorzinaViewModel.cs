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
            Korzine = ShopContext.GetContext().Korzine.Where(korzine => korzine.UserID == user.ID).ToList();

            Products = (from k in Korzine
                        join p in ShopContext.GetContext().Product.ToList() on k.ProductID equals p.ID
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
        private List<Korzine> korzine;
        public List<Korzine> Korzine
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
                    var item = Korzine.First(i => i.ID == id);
                    if (item.ValueProduct>0)
                    {
                        item.ValueProduct--;
                    }
                    if (item.ValueProduct==0)
                    {
                        ShopContext.GetContext().Korzine.Remove(item);
                    }
                    ShopContext.GetContext().SaveChanges();
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
                    var item = Korzine.First(i => i.ID == id);
                    item.ValueProduct++;
                    
                    ShopContext.GetContext().SaveChanges();
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
                    var item = Korzine.First(i => i.ID == id);
                    ShopContext.GetContext().Korzine.Remove(item);
                   
                    ShopContext.GetContext().SaveChanges();
                    page.UpdateDataContext();
                });
            }
        }
    }
}
