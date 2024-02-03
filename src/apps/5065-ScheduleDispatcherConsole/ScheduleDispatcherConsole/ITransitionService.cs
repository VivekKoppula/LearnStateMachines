namespace ScheduleDispatcherConsole
{
    public interface ITransitionService
    {
        void ExecuteTransition(State state, Input input);
        State ExecuteTransitionForScheduleDispatchWhenReady(State state, Input input);
        /// Ready, Input.ScheduleDispatch
    }
}