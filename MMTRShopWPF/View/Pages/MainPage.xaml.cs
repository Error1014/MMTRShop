using MMTRShopWPF.Model;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.Service;
using System;
using System.Windows.Controls;
using MMTRShopWPF.Commands;

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
