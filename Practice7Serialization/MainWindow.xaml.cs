using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.ViewModels;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
