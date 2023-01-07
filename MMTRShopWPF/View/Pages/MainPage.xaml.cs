using MMTRShopWPF.Service;
using MMTRShopWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MMTRShopWPF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static Frame MainFrame;

        public MainPage()
        {
            InitializeComponent();
            MainFrame = MyFrame;
            NavigationViewModel NavigationViewModel = new NavigationViewModel();
            DataContext = NavigationViewModel;

        }

        public MainPage(User user)
        {
            InitializeComponent();
            MainFrame = MyFrame;
            NavigationViewModel NavigationViewModel = new NavigationViewModel(user);
            DataContext = NavigationViewModel;
        }

        public MainPage(Admin admin)
        {
            InitializeComponent();
            MainFrame = MyFrame;
            NavigationViewModel NavigationViewModel = new NavigationViewModel(admin);
            DataContext = NavigationViewModel;
        }
    }
}
