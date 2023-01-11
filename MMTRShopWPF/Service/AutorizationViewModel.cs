using MMTRShopWPF.Model;
using MMTRShopWPF.Model;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.Service
{
    public class AutorizationViewModel : BaseViewModel
    {
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
                    var users = UnitOfWork.Users.GetAll();
                    foreach (var user in users)
                    {
                        if (user.Login == User.Login && user.Password == User.Password)
{
                            User = user;
                            client = UnitOfWork.Clients.GetAll().Where(c => c.UserId == User.Id).FirstOrDefault();
                            var admins = ShopContext.GetContext().Admin.ToList();
                            foreach (var admin in admins)
                            {
                                if (admin.UserId == user.Id)
                                {
                                    MainWindow.MainWindowFrame.Content = new MainPage(admin);
                                    return;
                                }
                            }
                            MainWindow.MainWindowFrame.Content = new MainPage(client);
                        }
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
  
                    var users = UnitOfWork.Users.GetAll();
                    foreach (var user in users)
                    {
                        if (user.Login == User.Login)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                            return;
                        }
                    }
                    if (CheckTwoPassword())
                    {
                        User = new User(User.Login, User.Password, User.LastName, User.FirstName, User.Patronymic);
                        UnitOfWork.Users.Add(User);
                        UnitOfWork.Users.Save();
                        client = new Client(User.Id,"","","");//Добавить поля клиента
                        MessageBox.Show(client.UserId.ToString());
                        UnitOfWork.Clients.Add(client);
                        UnitOfWork.Clients.Save();
                        MessageBox.Show("Регистрация прошла успешно");
                        User = new User();
                        Password2 = "";
                        SelectRejim();
                    }
                    else
                    {
                        MessageBox.Show("Пароли должны совпадать!");
                    }
                });
            }
        }
        private bool CheckTwoPassword()
        {
            return User.Password == Password2;
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
