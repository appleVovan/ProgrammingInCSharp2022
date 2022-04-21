using System;
using System.Windows;
using System.Windows.Controls;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Tools.Controls
{
    /// <summary>
    /// Interaction logic for PasswordBoxWithCaption.xaml
    /// </summary>
    public partial class PasswordBoxWithCaption : UserControl
    {
        public event Action<object,RoutedEventArgs> PasswordChanged;

        public void RaisePasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordChanged?.Invoke(sender, e);
        }

        public string Caption
        {
            get
            {
                return TbCaption.Text;
            }
            set
            {
                TbCaption.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return TbPassword.Password;
            }
            set
            {
                TbPassword.Password = value;
            }
        }
        public PasswordBoxWithCaption()
        {
            InitializeComponent();
        }
    }
}
