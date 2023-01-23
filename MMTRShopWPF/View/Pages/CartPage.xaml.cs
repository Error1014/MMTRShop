using MMTRShopWPF.Model;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.ViewModels;
using System.Windows.Controls;

namespace MMTRShopWPF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для KorzinaPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            CartViewModel cartViewModel = new CartViewModel();
            DataContext = cartViewModel;
        }
    }
}
