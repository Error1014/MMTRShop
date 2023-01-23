using MMTRShopWPF.Model;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using MMTRShopWPF.View.Pages;
using System;
using MMTRShopWPF.Service;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Commands;
using MMTRShopWPF.Service.Services;

namespace MMTRShopWPF.Commands
{
    public class NavigationViewModel : BaseViewModel
    {
        private NavigationService NavigationService = new NavigationService();
        public NavigationViewModel()
        {
            NavigarionManager.MainFrame.Content = new KatalogPage();
            VisibilityButtonClient = true;
            VisibilityButtonAdmin = false;
            VisibilityButtonOperator = false;
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
            VisibilityButtonClient = true;
            VisibilityButtonAdmin = false;
            VisibilityButtonOperator = false;
        }
        private void SetAdminSettings()
        {
            AccountManager.User = AccountManager.GetUserByIdAdmin();
            VisibilityButtonClient = false;
            VisibilityButtonAdmin = true;
            VisibilityButtonOperator = true;
        }
        private void SetOperatorSettings()
        {
            AccountManager.User = AccountManager.GetUserByIdOperator();
            VisibilityButtonClient = false;
            VisibilityButtonAdmin = false;
            VisibilityButtonOperator = true;
        }
        
        public bool VisibilityButtonClient { get; private set; }
        public bool VisibilityButtonAdmin { get; private set; }
        public bool VisibilityButtonOperator { get; private set; }

        public ICommand FavouritesNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    Message = NavigationService.CheckAutorisation();
                    if (!Message.IsError())
                    {
                        NavigarionManager.MainFrame.Content = new FavouritesPage();
                    }
                });
            }
        }
        public ICommand AccountNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    Message = NavigationService.CheckAutorisation();
                    if (!Message.IsError())
                    {
                        NavigarionManager.MainFrame.Content = new AccountPage();
                    }
                });
            }
        }
        public ICommand CloseWin
        {
            get
            {
                return new Commands((obj) =>
                {
                    Message = new Message(false);
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
                    Message = NavigationService.CheckAutorisation();
                    if (!Message.IsError())
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
                    Message = NavigationService.CheckAutorisation();
                    if (!Message.IsError())
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
                    Message = NavigationService.CheckAutorisation();
                    if (!Message.IsError())
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
