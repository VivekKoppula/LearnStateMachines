using FluentAssertions;
using ScheduleDispatcherConsole;
using System;

namespace DoorLockStateConsole.Tests;

public class ScheduleDispatcherLogicTests
{
    [Fact]
    public void ValidChangeStateTests()
    {
        var logicObject = new ScheduleDispatcherLogic();

        var finalState = logicObject.ChangeState(State.Created, Input.Admit);

        finalState.Should().Be(State.Ready);

        finalState = logicObject.ChangeState(State.Ready, Input.ScheduleDispatch);

        finalState.Should().Be(State.Running);

        finalState = logicObject.ChangeState(State.Running, Input.IOorEventWait);

        finalState.Should().Be(State.Waiting);

        finalState = logicObject.ChangeState(State.Waiting, Input.IOorEventComplete);

        finalState.Should().Be(State.Ready);

        finalState = logicObject.ChangeState(State.Running, Input.Exit);

        finalState.Should().Be(State.Terminated);

    }

    [Fact]
    public void InValidChangeStateTests()
    {
        var state = State.Created;
        var input = Input.ScheduleDispatch;
        
        ActAndAssert(state, input);

        state = State.Created;
        input = Input.Exit;

        ActAndAssert(state, input);
    }

    private void ActAndAssert(State state, Input input)
    {
        var logicObject = new ScheduleDispatcherLogic();

        var act = () => logicObject.ChangeState(state, input);

        act.Should().Throw<NotSupportedException>()
            .WithMessage($"{state} has no transition on {input}");
    }
}