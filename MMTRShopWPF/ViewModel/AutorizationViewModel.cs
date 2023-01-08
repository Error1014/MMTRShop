using MMTRShopWPF.Service;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModel
{
    public class AutorizationViewModel : BaseViewModel
    {

        public User MyUser;

        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        public ICommand AutorizationUser
{
get
{
                return new Commands((obj) =>
                {
                    var users = ShopContext.GetContext().User.ToList();
                    foreach (var user in users)
                    {
                        if (user.Login == login && user.Password == Password)
{
                            MyUser = user;
                            var admins = ShopContext.GetContext().Admin.ToList();
                            foreach (var admin in admins)
                            {
                                if (admin.ID == user.ID)
                                {
                                    MainWindow.MainWindowFrame.Content = new MainPage(admin);
                                    return;
                                }
                            }
                            MainWindow.MainWindowFrame.Content = new MainPage(user);
                        }
                    }
                });
            }
        }
        public ICommand AutorizationAdmin
        {
            get
            {
                return new Commands((obj) =>
                {
                    MainWindow.MainWindowFrame.Content = new MainPage(new Admin());
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
