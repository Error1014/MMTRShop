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
    /// Логика взаимодействия для InfoProductPage.xaml
    /// </summary>
    public partial class InfoProductPage : Page
    {
        public InfoProductPage()
        {
            InitializeComponent();
        }
        public InfoProductPage(Product product)
        {
            InitializeComponent();
            ProductVievModel productVievModel = new ProductVievModel(product);
            DataContext = productVievModel;
        }
    }
}
