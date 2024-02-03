namespace ScheduleDispatcherConsole
{
    public class TransitionService : ITransitionService
    {
        public void ExecuteTransition(State state, Input input)
        {
            Console.WriteLine($"The state transition from {state} with input {input} is executed.");
        }

        public State ExecuteTransitionForScheduleDispatchWhenReady(State state, Input input)
        {
            Console.WriteLine($"The state transition from {state} with input {input} is executed.");
            return state;
        }
    }
}