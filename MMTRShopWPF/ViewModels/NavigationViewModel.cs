using MMTRShopWPF.Model;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using MMTRShopWPF.View.Pages;
using System;
using MMTRShopWPF.Service;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.ViewModels;
using MMTRShopWPF.Service.Services;

namespace MMTRShopWPF.ViewModels
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
        public NavigationViewModel(Guid id)
        {
            NavigarionManager.MainFrame.Content = new KatalogPage();
            AccountManager.SetRoleById(id);
            if (AccountManager.Client != null)
            {
                SetClientSettings();
            }
            else if (AccountManager.Admin != null)
            {
                SetAdminSettings();
            }
            else if (AccountManager.Operator != null)
            {
                SetOperatorSettings();
            }
            TextButton = "Выйти";
        }

        private void SetClientSettings()
        {
            AccountManager.User = AccountManager.GetUserByIdClient();
            VisibilityButtonClient = Visibility.Visible;
            VisibilityButtonAdmin = Visibility.Collapsed;
        }
        private void SetAdminSettings()
        {
            AccountManager.User = AccountManager.GetUserByIdAdmin();
            VisibilityButtonClient = Visibility.Collapsed;
            VisibilityButtonAdmin = Visibility.Visible;
            VisibilityButtonOperator = Visibility.Visible;
        }
        private void SetOperatorSettings()
        {
            AccountManager.User = AccountManager.GetUserByIdOperator();
            VisibilityButtonClient = Visibility.Collapsed;
            VisibilityButtonAdmin = Visibility.Collapsed;
            VisibilityButtonOperator = Visibility.Visible;
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
                    if (CheckIsClient())
                    {
                        NavigarionManager.MainFrame.Content = new KorzinaPage();
                    }
                });
            }
        }

        public ICommand MyOrdersNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (CheckIsClient())
                    {
                        NavigarionManager.MainFrame.Content = new MyOrderPage();
                    }
                });
            }
        }

        public ICommand MyHistoryNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    if (CheckIsClient())
                    {
                        NavigarionManager.MainFrame.Content = new MyHistoryPage(); 
                    }
                });
            }
        }
        public ICommand OrderPageNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    NavigarionManager.MainFrame.Content = new OrdersPage();
                });
            }
        }
        public ICommand CategoryNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    NavigarionManager.MainFrame.Content = new CategoryPage();
                });
            }
        }
        private bool CheckIsClient()
        {
            if (AccountManager.Client == null)
            {
                MessageBox.Show("Для этого вам сперва необходимо войти в аккаутн");
                MainWindow.MainWindowFrame.Content = new AutorizationPage();
                return false;
            }
            else
            {
                return true;
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
        public Visibility VisibilityButtonOperator { get; private set; }

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
