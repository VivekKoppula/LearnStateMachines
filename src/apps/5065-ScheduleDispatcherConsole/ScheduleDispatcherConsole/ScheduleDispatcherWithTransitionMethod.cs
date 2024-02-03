namespace ScheduleDispatcherConsole
{
    public class ScheduleDispatcherWithTransitionMethod
    {
        public ScheduleDispatcherWithTransitionMethod(ITransitionService transitionMethod)
        {
            _transitionMethod = transitionMethod;
        }

        private ITransitionService _transitionMethod { get; }

        public State ChangeStateAndExecute(State current, Input input) =>
        (current, input) switch
        {
            (State.Created, Input.Admit) => ((Func<State, Input, State>)((state, input) => {
                _transitionMethod.ExecuteTransition(state, input);
                return State.Ready;
            }))(current, input),


            (State.Ready, Input.ScheduleDispatch) => ((Func<State, Input, State>)((state, input) => {
                var runningState = _transitionMethod.ExecuteTransitionForScheduleDispatchWhenReady(state, input);
                return runningState;
            }))(current, input),

            (State.Running, Input.IOorEventWait) => State.Waiting,
            (State.Waiting, Input.IOorEventComplete) => State.Ready,
            (State.Running, Input.Interrupt) => State.Ready,
            (State.Running, Input.Exit) => State.Terminated,
            _ => throw new NotSupportedException(
                $"{current} has no transition on {input}")
        };
    }
}