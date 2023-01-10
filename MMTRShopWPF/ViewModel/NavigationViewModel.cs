using MMTRShopWPF.Service;
using MMTRShopWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using MMTRShopWPF.View.Pages;

namespace MMTRShopWPF.ViewModel
{
    public class NavigationViewModel : BaseViewModel
    {
        public NavigationViewModel()
        {
            SelectPage = new KatalogPage(this);
            VisibilityButtonAdmin = Visibility.Collapsed;
            VisibilityButtonClient = Visibility.Visible;
            TextButton = "Войти";
        }
        public NavigationViewModel(User user)
        {
            SelectPage = new KatalogPage(this);
            User = user;
            VisibilityButtonClient = Visibility.Visible;
            VisibilityButtonAdmin = Visibility.Collapsed;
            TextButton = "Выйти";
}
public NavigationViewModel(Admin admin)
{
            SelectPage = new KatalogPage(this);
            Admin = admin;
            //User = ShopContext.GetContext().User.Where(user => user.Id == Admin.Id).FirstOrDefault();
            VisibilityButtonClient = Visibility.Collapsed;
            VisibilityButtonAdmin = Visibility.Visible;
            TextButton = "Выйти";
        }
        public static User User { get; private set; }
        public Admin Admin { get; private set; }

        private Page selectPage;
        public Page SelectPage
        {
            get { return selectPage; }
            set
            {
                selectPage = value;
                OnPropertyChanged(nameof(SelectPage));
            }
        }


        public ICommand KatalogNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    SelectPage = new KatalogPage(this);
                });
            }
        }

        public ICommand KorzinaNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (User == null)
                    {
                        MessageBox.Show("Для этого вам сперва необходимо войти в аккаутн");
                        MainWindow.MainWindowFrame.Content = new AutorizationPage();
                    }
                    else
                    {
                        SelectPage = new KorzinaPage(User);
                    }

                });
            }
        }

        public virtual ICommand AutorizationNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    MainWindow.MainWindowFrame.Content = new AutorizationPage();
                });
            }
        }

        public Visibility VisibilityButtonClient { get; private set; }
        public Visibility VisibilityButtonAdmin { get; private set; }

        public void SelectProduct(object sender)
        {
            var item = ((ListView)sender);
            if (Admin == null) SelectPage = new InfoProductPage((Product)item.SelectedItem);
            else SelectPage = new EditInfoProductPage((Product)item.SelectedItem);
        }
        public ICommand AddProduct
        {
            get
            {
                return new Commands((obj) =>
                {
                    SelectPage = new EditInfoProductPage(null);
                });
            }
        }
        public string TextButton { get; private set; }
    }
}
