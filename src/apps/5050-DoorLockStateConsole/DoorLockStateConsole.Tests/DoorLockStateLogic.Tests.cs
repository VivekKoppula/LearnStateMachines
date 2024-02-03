using FluentAssertions;
using System;

namespace DoorLockStateConsole.Tests
{
    public class DoorLockStateLogicTests
    {


        [Fact]
        public void ValidChangeStateTests()
        {
            var logicObject = new DoorLockStateLogic();

            var finalState = logicObject.ChangeState(State.Closed, Input.Open);

            finalState.Should().Be(State.Open);

            finalState = logicObject.ChangeState(State.Open, Input.Close);

            finalState.Should().Be(State.Closed);

            finalState = logicObject.ChangeState(State.Closed, Input.Lock);

            finalState.Should().Be(State.Locked);

            finalState = logicObject.ChangeState(State.Locked, Input.Unlock);

            finalState.Should().Be(State.Closed);

        }

        [Fact]
        public void InValidChangeStateTests()
        {
            var logicObject = new DoorLockStateLogic();

            var state = State.Open;
            var input = Input.Lock;

            var act = () => logicObject.ChangeState(state, input);

            act.Should().Throw<NotSupportedException>()
                .WithMessage($"The {state} state has no transition on {input}");

            state = State.Locked;
            input = Input.Open;

            act = () => logicObject.ChangeState(state, input);

            act.Should().Throw<NotSupportedException>()
                .WithMessage($"The {state} state has no transition on {input}");
        }
    }
}