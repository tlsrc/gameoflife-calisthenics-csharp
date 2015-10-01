using GameOfLife.State;
using GameOfLife.Transition;
using Xunit;

namespace GameOfLifeTest
{
    public class TransitionTest
    {
        public static TheoryData<Transition> TransitionsToAlive = new TheoryData<Transition>
        {
            new Transition(new Dead(), new AliveNeighborsCount(3)),
            new Transition(new Alive(), new AliveNeighborsCount(2))
        };

        public static TheoryData<object> TransitionsToDead = new TheoryData<object>
        {
            new Transition(new Dead(), new AliveNeighborsCount(2)),
            new Transition(new Alive(), new AliveNeighborsCount(4)),
            new Transition(new Alive(), new AliveNeighborsCount(1))
        };

        [Theory, MemberData("TransitionsToAlive")]
        public void ShouldBecomeAlive(Transition transition)
        {
            Assert.Equal(new Alive(), transition.Execute());
        }

        [Theory, MemberData("TransitionsToDead")]
        public void ShouldBecomeDead(Transition transition)
        {
            Assert.Equal(new Dead(), transition.Execute());
        }

    }
}
