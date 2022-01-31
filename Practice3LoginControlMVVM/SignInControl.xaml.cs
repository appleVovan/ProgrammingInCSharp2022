using System;
using System.Windows;
using System.Windows.Controls;

namespace KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM
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
