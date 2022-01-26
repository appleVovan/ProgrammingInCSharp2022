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

namespace KMA.ProgrammingInCSharp2022.Practice2LoginWindow
{
    /// <summary>
    /// Interaction logic for SignInControl.xaml
    /// </summary>
    public partial class SignInControl : UserControl
    {
        public SignInControl()
        {
            InitializeComponent();
        }

        private void BSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TBLogin.Text) ||
                String.IsNullOrWhiteSpace(PBPassword.Password))
            {
                MessageBox.Show("Login or password is empty!");
                return;
            }
            MessageBox.Show($"Login successful for user {TBLogin.Text}");
        }

        private void BSignUp_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TBLogin.Text) ||
                String.IsNullOrWhiteSpace(PBPassword.Password))
            {
                MessageBox.Show("Login or password is empty!");
                return;
            }
            MessageBox.Show($"User with name {TBLogin.Text} was created");
        }

        private void BCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
