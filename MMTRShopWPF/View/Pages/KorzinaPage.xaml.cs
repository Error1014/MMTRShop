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
        private  Client user;
        public KorzinaPage(Client user)
        {
            InitializeComponent();
            this.user = user;
            UpdateDataContext();
        }

        public void UpdateDataContext()
        {
            korzinaViewModel = new KorzinaViewModel(this);
            DataContext = korzinaViewModel;
        }
    }
}
