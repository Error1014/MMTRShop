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
using MMTRShopWPF.Commands;

namespace MMTRShopWPF.ViewModels
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

        private ICommand favouritesNavigate;
        public ICommand FavouritesNavigate
        {
            get
            {
                if (favouritesNavigate == null) favouritesNavigate = new NavigateCommand(this, new FavouritesPage(),true);
                return favouritesNavigate;
            }
        }

        //public ICommand accountNavigate;
        //public ICommand AccountNavigate
        //{
        //    get
        //    {
        //        if (accountNavigate == null) accountNavigate = new NavigateCommand(this, new AccountPage(),true);
        //        return accountNavigate;
        //    }
        //}

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

        private ICommand katalogNavigate;
        public ICommand KatalogNavigate
        {
            get
            {
                if (katalogNavigate == null) katalogNavigate = new NavigateCommand(this, new KatalogPage(),false);
                return katalogNavigate;
            }
        }

        private ICommand cartNavigate;
        public ICommand CartNavigate
        {
            get
            {
                if (cartNavigate == null) cartNavigate = new NavigateCommand(this, new CartPage(),true);
                return cartNavigate;
            }
        }

        private ICommand myOrdersNavigate;
        public ICommand MyOrdersNavigate
        {
            get
            {
                if (myOrdersNavigate == null) myOrdersNavigate = new NavigateCommand(this, new MyOrderPage(),true);
                return myOrdersNavigate;
            }
        }

        private ICommand myHistoryNavigate;
        public ICommand MyHistoryNavigate
        {
            get
            {
                if (myHistoryNavigate == null) myHistoryNavigate = new NavigateCommand(this, new MyHistoryPage(),true);
                return myHistoryNavigate;
            }
        }
        private ICommand orderPageNavigate;
        public ICommand OrderPageNavigate
        {
            get
            {
                if (orderPageNavigate == null) orderPageNavigate = new NavigateCommand(this, new OrdersPage(),true);
                return orderPageNavigate;
            }
        }
        private ICommand categoryNavigate;
        public ICommand CategoryNavigate
        {
            get
            {
                if (categoryNavigate == null) categoryNavigate = new NavigateCommand(this, new CategoryPage(),true);
                return categoryNavigate;
            }
        }

        private ICommand autorizationNavigate;
        public ICommand AutorizationNavigate
        {
            get
            {
                if (autorizationNavigate == null) autorizationNavigate = new NavigateCommand(this, new AutorizationPage(), false);
                return autorizationNavigate;
            }
        }

        private ICommand addProductNavigate;
        public ICommand AddProductNavigate
        {
            get
            {
                if (addProductNavigate == null) addProductNavigate = new NavigateCommand(this, new EditInfoProductPage(),true);
                return addProductNavigate;
            }
        }
        public string TextButton { get; private set; }
    }
}
