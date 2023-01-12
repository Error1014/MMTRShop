using MMTRShopWPF.Model;
using MMTRShopWPF.Service;
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
    /// Логика взаимодействия для FavouritesPage.xaml
    /// </summary>
    public partial class FavouritesPage : Page
    {
        public static FavouritesViewModel FavouritesViewModel;
        private Client user;
        public FavouritesPage(Client user)
        {
            InitializeComponent();
            this.user = user;
            UpdateDataContext();
        }

        public void UpdateDataContext()
        {
            FavouritesViewModel = new FavouritesViewModel(user, this);
            DataContext = FavouritesViewModel;
        }
    }
}
