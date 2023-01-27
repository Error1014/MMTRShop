using MMTRShop.Model;
using MMTRShop.Service.Services;
using MMTRShop.Service;
using System;
using System.Windows.Controls;
using MMTRShopWPF.ViewModels;

namespace MMTRShopWPF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigarionManager.MainFrame = MyFrame;
            NavigationViewModel NavigationViewModel = new NavigationViewModel();
            DataContext = NavigationViewModel;

        }
        public MainPage(Guid id)
        {
            InitializeComponent();
            NavigarionManager.MainFrame = MyFrame;
            NavigationViewModel NavigationViewModel = new NavigationViewModel(id);
            DataContext = NavigationViewModel;

        }
    }
}
