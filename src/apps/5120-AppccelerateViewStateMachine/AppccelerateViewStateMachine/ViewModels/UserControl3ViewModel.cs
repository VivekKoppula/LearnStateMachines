using AppccelerateStateMachine.Infrastructure;
using AppccelerateViewStateMachine.Infrastructure;
using AppccelerateViewStateMachine.StateMachine;
using System.Windows.Input;

namespace AppccelerateViewStateMachine.ViewModels
{
    public class UserControl3ViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goTo1 = default!, _goTo2 = default!;

        private readonly IViewStateMachine _stateMachine;

        public UserControl3ViewModel(IViewStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public ICommand GoTo1
        {
            get { return _goTo1 ??= new RelayCommand(x => { _stateMachine.FireEvent(Events.GoToView1); }); }
        }

        public ICommand GoTo2
        {
            get { return _goTo2 ??= new RelayCommand(x => { _stateMachine.FireEvent(Events.GoToView2); }); }
        }

        public void FireEvent(Events events)
        {
            throw new System.NotImplementedException();
        }
    }
}
