using MMTRShopWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MMTRShopWPF.ViewModel
{
    public class KorzinaViewModel : BaseViewModel
{
public KorzinaViewModel(User myUser)
{
            user = myUser;
            Korzine = ShopContext.GetContext().Korzine.Where(korzine => korzine.UserID == user.ID).ToList();
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
        private static List<Korzine> korzine;
        public List<Korzine> Korzine
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
                    MessageBox.Show("-");
                });
            }
        }
        public ICommand ProductPlus
        {
            get
            {
                return new Commands((obj) =>
                {
                    MessageBox.Show("+");
                });
            }
        }
    }
}
