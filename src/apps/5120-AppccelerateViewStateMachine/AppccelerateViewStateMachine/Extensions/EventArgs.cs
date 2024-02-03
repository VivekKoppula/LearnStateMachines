using System;

namespace AppccelerateStateMachine.Extensions
{
    public static partial class EventRaiser
    {
        public class EventArgs<T> : EventArgs
        {
            public EventArgs(T value)
            {
                Value = value;
            }

            public T Value { get; private set; }
        }


    }
}
