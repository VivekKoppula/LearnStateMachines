using System.Windows;
using AppccelerateViewStateMachine.ViewModels;

namespace AppccelerateStateMachine.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            DataContext= mainWindowViewModel;
            InitializeComponent();
        }
    }
}
