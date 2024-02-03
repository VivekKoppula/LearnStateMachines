using EmployeeManager.ViewModels;
using System.Windows;

namespace EmployeeManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window
    {
        public ShellWindow()
        {
            InitializeComponent();
            DataContext = new ShellWindowViewModel();
        }
    }
}
