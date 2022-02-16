using System.Windows;
using System.Windows.Controls;
using KMA.ProgrammingInCSharp2022.Practice6Async.ViewModels;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.Views
{
    /// <summary>
    /// Interaction logic for SignInControl.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        private void PbPassword_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ((SignUpViewModel)DataContext).Password = PbPassword.Password;
        }
    }
}
