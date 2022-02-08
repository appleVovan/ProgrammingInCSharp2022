﻿using System.Windows;
using System.Windows.Controls;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.ViewModels;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation.Views
{
    /// <summary>
    /// Interaction logic for SignInControl.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        private SignUpViewModel _viewModel;

        public SignUpView()
        {
            InitializeComponent();
            DataContext = _viewModel = new SignUpViewModel();
        }

        private void PbPassword_OnLostFocus(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PbPassword.Password;
        }
    }
}