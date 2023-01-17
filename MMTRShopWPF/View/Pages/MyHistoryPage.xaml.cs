using MMTRShopWPF.ViewModels;
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
    /// Логика взаимодействия для MyHistoryPage.xaml
    /// </summary>
    public partial class MyHistoryPage : Page
    {
        public MyHistoryPage()
        {
            InitializeComponent();
            MyHistoryViewModel myHistoryViewModel = new MyHistoryViewModel();
            DataContext = myHistoryViewModel;
        }
    }
}
