﻿using MMTRShopWPF.Model;
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
