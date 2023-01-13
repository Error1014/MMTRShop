using MMTRShopWPF.Model;
using MMTRShopWPF.Service;
using System.Windows.Controls;

namespace MMTRShopWPF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для KorzinaPage.xaml
    /// </summary>
    public partial class KorzinaPage : Page
    {
        public static KorzinaViewModel korzinaViewModel;
        public KorzinaPage()
        {
            InitializeComponent();
            UpdateDataContext();
        }

        public void UpdateDataContext()
        {
            korzinaViewModel = new KorzinaViewModel(this);
            DataContext = korzinaViewModel;
        }
    }
}
