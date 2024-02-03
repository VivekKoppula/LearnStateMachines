using AppccelerateStateMachine.Infrastructure;
using AppccelerateViewStateMachine.Infrastructure;
using AppccelerateViewStateMachine.StateMachine;
using System.Windows.Input;

namespace AppccelerateViewStateMachine.ViewModels
{
    public class UserControl1ViewModel : BaseViewModel, IPageViewModel
    {
        private readonly IViewStateMachine _stateMachine;

        private ICommand _goTo2 = default!, _goTo3 = default!;

        public UserControl1ViewModel(IViewStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public ICommand GoTo2
        {
            get
            {
                return _goTo2 ??= new RelayCommand(x =>
                {
                    _stateMachine.FireEvent(Events.GoToView2);
                });
            }
        }

        public ICommand GoTo3
        {
            get
            {
                return _goTo3 ??= new RelayCommand(x =>
                {
                    _stateMachine.FireEvent(Events.GoToView3);
                });
            }
        }
    }


}
