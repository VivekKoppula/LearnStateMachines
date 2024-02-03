using AppccelerateStateMachine.Infrastructure;
using AppccelerateViewStateMachine.Infrastructure;
using AppccelerateViewStateMachine.StateMachine;
using System.Windows.Input;

namespace AppccelerateViewStateMachine.ViewModels
{
    public class UserControl2ViewModel : BaseViewModel, IPageViewModel
    {
        private readonly IViewStateMachine _stateMachine;
        private ICommand _goTo1 = default!;

        public UserControl2ViewModel(IViewStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public ICommand GoTo1
        {
            get { return _goTo1 ??= new RelayCommand(x => { _stateMachine.FireEvent(Events.GoToView1); }); }
        }
    }

}
