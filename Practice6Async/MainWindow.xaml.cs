using System.Windows;
using KMA.ProgrammingInCSharp2022.Practice6Async.ViewModels;

namespace KMA.ProgrammingInCSharp2022.Practice6Async
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
