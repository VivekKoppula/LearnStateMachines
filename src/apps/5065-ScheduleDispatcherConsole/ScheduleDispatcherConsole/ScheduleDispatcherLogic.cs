using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDispatcherConsole
{

    public enum State { Created, Ready, Running, Waiting, Terminated }
    public enum Input
    {
        Admit, ScheduleDispatch, Interrupt,
        IOorEventWait, IOorEventComplete, Exit
    }
    public class ScheduleDispatcherLogic
    {
        public State ChangeState(State current, Input input) =>
        (current, input) switch
        {
            (State.Created, Input.Admit) => State.Ready,
            (State.Ready, Input.ScheduleDispatch) => State.Running,
            (State.Running, Input.IOorEventWait) => State.Waiting,
            (State.Waiting, Input.IOorEventComplete) => State.Ready,
            (State.Running, Input.Interrupt) => State.Ready,
            (State.Running, Input.Exit) => State.Terminated,
            _ => throw new NotSupportedException(
                $"{current} has no transition on {input}")
        };
    }
}