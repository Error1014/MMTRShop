using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class AutorizationViewModel : BaseViewModel
    {
        private AutorizationService AutorizationService = new AutorizationService();
        public AutorizationViewModel()
        {
            VisibilityRejimRegistration = Visibility.Collapsed;
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
        private Visibility visibilityRejimRegistration;
        public Visibility VisibilityRejimRegistration
        {
            get { return visibilityRejimRegistration; }
            set
            {
                visibilityRejimRegistration = value;
                OnPropertyChanged(nameof(VisibilityRejimRegistration));
            }
        }

        private Visibility visibilityRejimAutorization;
        public Visibility VisibilityRejimAutorization
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

        public ICommand AutorizationUser
        {
        get
        {
                return new Commands((obj) =>
                {
                    Message = AutorizationService.CheckCorrectLoginPassword(User.Login, User.Password);
                    if (!Message.IsError())
                    {
                        Guid id = AutorizationService.GetUserId(User.Login, User.Password);
                        MainWindow.MainWindowFrame.Content = new MainPage(id);
                    }

                });
            }
        }
        public ICommand OpenRegistrationPanel
        {
            get
            {
                return new Commands((obj) =>
                {
                    SelectRejim();

                });
            }
        }
        void SelectRejim()
        {
            isRegistration = !isRegistration;
            if (isRegistration)
            {
                VisibilityRejimAutorization = Visibility.Collapsed;
                VisibilityRejimRegistration = Visibility.Visible;
                TextBtnRegistration = "Отменить";
            }
            else
            {
                VisibilityRejimAutorization = Visibility.Visible;
                VisibilityRejimRegistration = Visibility.Collapsed;
                TextBtnRegistration = "Зарегистрироваться";
            }
            
        }
        public ICommand RegistrationUser
        {
            get
            {
                return new Commands((obj) =>
                {
                    Message = AutorizationService.Registration(user, Password2);
                    if (!Message.IsError())
                    {
                        Password2 = "";
                        User = new User();
                        SelectRejim();
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
                    MainWindow.MainWindowFrame.Content = new MainPage();
                });
            }
        }
        
    }
}
