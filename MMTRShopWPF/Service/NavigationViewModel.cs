using MMTRShopWPF.Model;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using MMTRShopWPF.View.Pages;

namespace MMTRShopWPF.Service
{
    public class NavigationViewModel : BaseViewModel
    {
        public NavigationViewModel()
        {
            NavigarionManager.MainFrame.Content = new KatalogPage();
            VisibilityButtonAdmin = Visibility.Collapsed;
            VisibilityButtonClient = Visibility.Visible;
            TextButton = "Войти";
        }
        public NavigationViewModel(User user)
        {
            NavigarionManager.MainFrame.Content = new KatalogPage();
            AccountManager.User = user;
            VisibilityButtonClient = Visibility.Visible;
            VisibilityButtonAdmin = Visibility.Collapsed;
            TextButton = "Выйти";
        }
        public NavigationViewModel(Client client)
        {
            NavigarionManager.MainFrame.Content = new KatalogPage();
            AccountManager.Client = client;
            AccountManager.User = ShopContext.GetContext().User.Where(user => user.Id == AccountManager.Client.UserId).FirstOrDefault();
            VisibilityButtonClient = Visibility.Visible;
            VisibilityButtonAdmin = Visibility.Collapsed;
            TextButton = "Выйти";
        }
        public NavigationViewModel(Admin admin)
        {
            NavigarionManager.MainFrame.Content = new KatalogPage();
            AccountManager.Admin = admin;
            AccountManager.User = ShopContext.GetContext().User.Where(user => user.Id == AccountManager.Admin.UserId).FirstOrDefault();
            VisibilityButtonClient = Visibility.Collapsed;
            VisibilityButtonAdmin = Visibility.Visible;
            TextButton = "Выйти";
        }

        
        public ICommand FavouritesNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (AccountManager.Client == null)
                    {
                        MessageBox.Show("Для этого вам сперва необходимо войти в аккаутн");
                        MainWindow.MainWindowFrame.Content = new AutorizationPage();
                    }
                    else
                    {
                        NavigarionManager.MainFrame.Content = new FavouritesPage(AccountManager.Client);
                    }

                });
            }
        }

        public ICommand KatalogNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    NavigarionManager.MainFrame.Content = new KatalogPage();
                });
            }
        }

        public ICommand KorzinaNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (AccountManager.Client == null)
                    {
                        MessageBox.Show("Для этого вам сперва необходимо войти в аккаутн");
                        MainWindow.MainWindowFrame.Content = new AutorizationPage();
                    }
                    else
                    {
                        NavigarionManager.MainFrame.Content = new KorzinaPage(AccountManager.Client);
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
                    AccountManager.ResetAccount();
                    MainWindow.MainWindowFrame.Content = new AutorizationPage();
                });
            }
        }

        public Visibility VisibilityButtonClient { get; private set; }
        public Visibility VisibilityButtonAdmin { get; private set; }

        public void SelectProduct(object sender)
        {
            var item = ((ListView)sender);
            if (AccountManager.Admin == null) NavigarionManager.MainFrame.Content = new InfoProductPage((Product)item.SelectedItem);
            else NavigarionManager.MainFrame.Content = new EditInfoProductPage((Product)item.SelectedItem);
        }
        public ICommand AddProduct
        {
            get
            {
                return new Commands((obj) =>
                {
                    NavigarionManager.MainFrame.Content = new EditInfoProductPage(null);
                });
            }
        }
        public string TextButton { get; private set; }
    }
}
