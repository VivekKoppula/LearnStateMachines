using Appccelerate.StateMachine;
using static AppccelerateStateMachine.Extensions.EventRaiser;
using System;
using Appccelerate.StateMachine.Machine;

namespace AppccelerateViewStateMachine.StateMachine
{
    public class ViewStateMachine : IViewStateMachine
    {
        private readonly PassiveStateMachine<States, Events> _psm;
        private string _localVariable;

        public ViewStateMachine()
        {
            _localVariable = "";

            var builder = new StateMachineDefinitionBuilder<States, Events>();


            builder.In(States.View1)
               .On(Events.GoToView2)
               .Goto(States.View2)
               .Execute(() =>
               {
                   ChangeViewModel(1);
                   // Any other actions you want...
               });

            builder.In(States.View1)
               .On(Events.GoToView3)
               .Goto(States.View3)
               .Execute(() =>
               {
                   ChangeViewModel(2);
               });

            builder.In(States.View2)
               .On(Events.GoToView1)
               .Goto(States.View1)
               .Execute(() => { ChangeViewModel(0); });

            builder.In(States.View3)
               .On(Events.GoToView1)
               .Goto(States.View1)
               .Execute(() => { ChangeViewModel(0); });

            builder.In(States.View3)
               .On(Events.GoToView2)
               .Goto(States.View2)
               .Execute(() => { ChangeViewModel(1); });

            builder.WithInitialState(States.View1);

            var definition = builder
                .Build();

            _psm = definition
                .CreatePassiveStateMachine();

            _psm.Start();
        }

        public void FireEvent(Events events)
        {
            _psm.Fire(events);
        }

        public event EventHandler<EventArgs<int>> ViewModelEvent = default!;

        public void ChangeViewModel(int index)
        {
            ViewModelEvent.Raise(this, index);
        }

        private void SetLocalVariables(string variable)
        {
            _localVariable = variable;
        }
    }
}
