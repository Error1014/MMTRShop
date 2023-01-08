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

namespace MMTRShopWPF.Components
{
    /// <summary>
    /// Логика взаимодействия для BindingPassword.xaml
    /// </summary>
    public partial class BindingPassword : UserControl
    {

        private bool isPasswordChangig;

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindingPassword), new PropertyMetadata(string.Empty, PasswordPropertyChanged));

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindingPassword passwordBox)
            {
                passwordBox.UpdatePassword();
            }
        }

        public BindingPassword()
        {
            InitializeComponent();
        }

        private void PasswordBoxChanged(object sender, RoutedEventArgs e)
        {
            isPasswordChangig = true;
            Password = passwordBox.Password;
            isPasswordChangig = false;
        }
        private void UpdatePassword()
        {
            if (!isPasswordChangig) passwordBox.Password = Password;
        }

    }
}
