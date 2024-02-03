using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleDispatcherConsole.Tests
{
    public class ScheduleDispatcherWithTransitionMethodTest
    {
        
        
        [Fact]
        public void ValidStateChangeWithExecutionTests()
        {
            var transitionServiceMock = new Mock<ITransitionService>(MockBehavior.Strict);
        
            // transitionServiceMock.Setup(transitionService => transitionService.ExecuteTransitionForScheduleDispatchWhenReady(It.IsAny<State>(), It.IsAny<Input>())).Returns(State.Running);

            transitionServiceMock.Setup(transitionService => transitionService.ExecuteTransitionForScheduleDispatchWhenReady(State.Ready, Input.ScheduleDispatch)).Returns(State.Running);

            var logicObject = new ScheduleDispatcherWithTransitionMethod(transitionServiceMock.Object);

            var finalState = logicObject.ChangeStateAndExecute(State.Ready, Input.ScheduleDispatch);

            finalState.Should().Be(State.Running);

        }

        // Similarly you can write other tests as well.
    }
}
