using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MMTRShopWPF.Commands
{
    public class AccountViewModel:BaseViewModel
    {
        private AccountService AccountService = new AccountService();
        public AccountViewModel()
        {
            User = AccountService.GetUser();
            Client = AccountService.GetClient();
            VisibilityEditButton = true;
        }

        private User user = new User();
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        
        private Client client = new Client();
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        private bool visibilityEditButton;
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
                return new BaseCommand((obj) =>
                {
                    VisibilityEditButton = false;
                });
            }
        }
        public ICommand Cancel
        {
            get
            {
                return new BaseCommand((obj) =>
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
                return new BaseCommand((obj) =>
                {
                    VisibilityEditButton = true;
                    AccountService.Save();
                });
            }
        }
    }
}
