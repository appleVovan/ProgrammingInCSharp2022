using System.Windows;
using System.Windows.Controls;
using KMA.ProgrammingInCSharp2022.Practice6Async.ViewModels;

namespace KMA.ProgrammingInCSharp2022.Practice6Async.Views
{
    /// <summary>
    /// Interaction logic for SignInControl.xaml
    /// </summary>
    public partial class SignInView : UserControl
    {
        public SignInView()
        {
            InitializeComponent();
        }

        private void PbPassword_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ((SignInViewModel)DataContext).Password = PbPassword.Password;
        }
    }
}
