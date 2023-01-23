using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.Commands
{
    public class AutorizationViewModel : BaseViewModel
    {
        private AutorizationService AutorizationService = new AutorizationService();
        public AutorizationViewModel()
        {
            VisibilityRejimRegistration = false;
            VisibilityRejimAutorization = true;
            TextBtnRegistration = "Зарегистрироваться";
        }
        private Client client = new Client();
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

        private string password2;
        public string Password2
        {
            get
            {
                return password2;
            }
            set
            {
                password2 = value;
                OnPropertyChanged(nameof(Password2));
            }
        }

        private bool isRegistration = false;
        public bool IsRegistration
        {
            get { return isRegistration; }
            set
            {
                isRegistration = value;
                VisibilityRejimRegistration = value;
                VisibilityRejimAutorization = !value;
                TextBtnRegistration = value==true? "Отменить": "Зарегистрироваться";
                OnPropertyChanged(nameof(IsRegistration));
            }
        }
        private bool visibilityRejimRegistration;
        public bool VisibilityRejimRegistration
        {
            get { return visibilityRejimRegistration; }
            set
            {
                visibilityRejimRegistration = value;
                OnPropertyChanged(nameof(VisibilityRejimRegistration));
            }
        }

        private bool visibilityRejimAutorization;
        public bool VisibilityRejimAutorization
        {
            get { return visibilityRejimAutorization; }
            set
            {
                visibilityRejimAutorization = value;
                OnPropertyChanged(nameof(VisibilityRejimAutorization));
            }
        }

        private string textBtnRegistration;
        public string TextBtnRegistration
        {
            get { return textBtnRegistration; }
            set
            {
                textBtnRegistration = value;
                OnPropertyChanged(nameof (TextBtnRegistration));
            }
        }
        private ICommand autorizationUser;
        public ICommand AutorizationUser
        {
        get
        {
                if (autorizationUser == null) autorizationUser = new AutorizationUserCommand(this);
                return autorizationUser;
            }
        }
        private ICommand openRegistrationPanel;
        public ICommand OpenRegistrationPanel
        {
            get
            {
                if (openRegistrationPanel == null) openRegistrationPanel = new OpenRegistrationPanelCommand (this);
                return openRegistrationPanel;
            }
        }
        private ICommand registrationUser;
        public ICommand RegistrationUser
        {
            get
            {
                if (registrationUser == null) registrationUser = new RegistrationUserCommand(this);
                return registrationUser;
            }
        }
        
        public ICommand KatalogNavigate
        {
            get
            {
                return new Commands((obj) =>
                {
                    MainWindow.MainWindowFrame.Content = new MainPage();
                });
            }
        }
        
    }
}
