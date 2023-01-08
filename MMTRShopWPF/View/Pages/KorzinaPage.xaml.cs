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
    /// Логика взаимодействия для KorzinaPage.xaml
    /// </summary>
    public partial class KorzinaPage : Page
    {
        public static KorzinaViewModel korzinaViewModel;
        private User user;
        public KorzinaPage(User user)
        {
            InitializeComponent();
            korzinaViewModel = new KorzinaViewModel(user);
            this.user=user;
            DataContext = korzinaViewModel;
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            korzinaViewModel = new KorzinaViewModel(user);
            DataContext = korzinaViewModel;
        }
    }
}
