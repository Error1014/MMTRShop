using MMTRShopWPF.Commands;
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
    /// Логика взаимодействия для MyOrderPage.xaml
    /// </summary>
    public partial class MyOrderPage : Page
    {
        public MyOrderPage()
        {
            InitializeComponent();
            MyOrderViewModel myOrderVievModel = new MyOrderViewModel();
            DataContext = myOrderVievModel;
        }
    }
}
