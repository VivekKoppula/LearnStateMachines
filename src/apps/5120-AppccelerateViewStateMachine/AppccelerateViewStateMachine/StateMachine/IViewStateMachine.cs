using System;
using static AppccelerateStateMachine.Extensions.EventRaiser;

namespace AppccelerateViewStateMachine.StateMachine
{
    public interface IViewStateMachine
    {
        void FireEvent(Events events);
        void ChangeViewModel(int index);
        event EventHandler<EventArgs<int>> ViewModelEvent;
    }
}
