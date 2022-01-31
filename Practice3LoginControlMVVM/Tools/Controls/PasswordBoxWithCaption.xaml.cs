using System.Windows.Controls;

namespace KMA.ProgrammingInCSharp2022.Practice3LoginControlMVVM.Tools.Controls
{
    /// <summary>
    /// Interaction logic for PasswordBoxWithCaption.xaml
    /// </summary>
    public partial class PasswordBoxWithCaption : UserControl
    {
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
