using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Commands;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class AccountViewModel:BaseViewModel
    {
        private AccountService AccountService = new AccountService();

        private User user;
        public User User
        {
            get 
            {
                if (user==null) User = AccountService.GetUser();
                return user; 
            }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private Client client;
        public Client Client
        {
            get 
            {
                if (client == null) Client = AccountService.GetClient();
                return client;
            }
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        private bool visibilityEditButton = true;
        public bool VisibilityEditButton
        {
            get { return visibilityEditButton; }
            set
            {
                visibilityEditButton = value;
                VisibilitySaveAndCancelButton = !value;
                OnPropertyChanged(nameof(VisibilityEditButton));
            }
        }
        private bool visibilitySaveAndCancelButton;
        public bool VisibilitySaveAndCancelButton
        {
            get { return visibilitySaveAndCancelButton; }
            set
            {
                visibilitySaveAndCancelButton = value;
                OnPropertyChanged(nameof(VisibilitySaveAndCancelButton));
            }
        }

        public ICommand Edit
        {
            get
            {
                return new Commands((obj) =>
                {
                    VisibilityEditButton = false;
                });
            }
        }
        public ICommand Cancel
        {
            get
            {
                return new Commands((obj) =>
                {
                    VisibilityEditButton = true;
                    NavigarionManager.MainFrame.Content = new AccountPage();

                });
            }
        }
        public ICommand Save
        {
            get
            {
                return new Commands((obj) =>
                {
                    VisibilityEditButton = true;
                    AccountService.Save();
                });
            }
        }
    }
}
