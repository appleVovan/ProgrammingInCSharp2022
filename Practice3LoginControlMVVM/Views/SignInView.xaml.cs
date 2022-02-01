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

        private void PbPassword_OnLostFocus(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PbPassword.Password;
        }
    }
}
