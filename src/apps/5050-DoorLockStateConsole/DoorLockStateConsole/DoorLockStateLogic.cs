using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorLockStateConsole
{
    public enum State { Open, Closed, Locked }
    public enum Input { Open, Close, Lock, Unlock }
    public class DoorLockStateLogic
    {
        public State ChangeState(State current, Input input) =>
        (current, input) switch
        {
            (State.Closed, Input.Open) => State.Open,
            (State.Open, Input.Close) => State.Closed,
            (State.Closed, Input.Lock) => State.Locked,
            (State.Locked, Input.Unlock) => State.Closed,
            _ => throw new NotSupportedException(
                $"The {current} state has no transition on {input}")
        };
    }
}
