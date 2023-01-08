using MMTRShopWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace MMTRShopWPF.ViewModel
{
    public class KorzinaViewModel : BaseViewModel
    {
        public KorzinaViewModel(User myUser)
        {
            user = myUser;
            
            var korzins= ShopContext.GetContext().Korzine.Where(korzine => korzine.UserID == user.ID).ToList();
            Korzine = new ObservableCollection<Korzine>(korzins);
            Products = (from k in korzine
                        join p in ShopContext.GetContext().Product.ToList() on k.ProductID equals p.ID
                        select p).ToList();
        }
        private static User user;
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
        private static ObservableCollection<Korzine> korzine;
        public ObservableCollection<Korzine> Korzine
        {
            get
            {
                return korzine;
            }
            set
            {
                korzine = value;
                OnPropertyChanged(nameof(User));
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
                    item.ValueProduct--;
                    
                    ShopContext.GetContext().SaveChanges();
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
                });
            }
        }
    }
}
