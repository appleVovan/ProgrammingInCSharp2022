using System;
using System.Windows;
using System.Windows.Controls;
using KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.ViewModels;

namespace KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Views
{
    /// <summary>
    /// Interaction logic for SignInControl.xaml
    /// </summary>
    public partial class SignInView : UserControl
    {
        private SignInViewModel _viewModel;

        public SignInView()
        {
            InitializeComponent();
            DataContext = _viewModel = new SignInViewModel();
        }

        private void BSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbLogin.Text) ||
                String.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Login or password is empty!");
                return;
            }
            MessageBox.Show($"Login successful for user {TbLogin.Text}");
        }

        private void BSignUp_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbLogin.Text) ||
                String.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Login or password is empty!");
                return;
            }
            MessageBox.Show($"User with name {TbLogin.Text} was created");
        }

        private void BCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
