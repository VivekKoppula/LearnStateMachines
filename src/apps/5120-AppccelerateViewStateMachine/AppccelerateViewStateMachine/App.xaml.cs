using System.Windows;
using AppccelerateStateMachine.Views;
using AppccelerateViewStateMachine.StateMachine;
using Unity;

namespace AppccelerateStateMachine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();
            container.RegisterType<IViewStateMachine, ViewStateMachine>();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
