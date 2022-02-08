using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice4Navigation.Views;

namespace KMA.ProgrammingInCSharp2022.Practice4Navigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = new SignInView();
        }
    }
}
