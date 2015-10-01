using System.Collections;
using System.Collections.Generic;
using GameOfLife;
using GameOfLife.Space;
using GameOfLife.State;
using Moq;
using Xunit;

namespace GameOfLifeTest
{
    public class EngineTest
    {
        [Fact]
        public void TheEngineBuildsTransitionFromTheUniverse()
        {
            var originalUniverse = new Mock<IStateHolder>();
            var nextUniverse = new Mock<IStateHolder>();
            originalUniverse.Setup(ou => ou.EmptyClone()).Returns(nextUniverse.Object);
            originalUniverse.Setup(ou => ou.GetState(It.IsAny<IPosition>())).Returns(new Alive());
            nextUniverse.Setup(nu => nu.GetState(It.IsAny<IPosition>())).Returns(new Dead());
            var spaceLimits = new TestingSpaceLimits();
            
            var engine = new Engine<CartesianPosition>(originalUniverse.Object, spaceLimits);
            engine.NextGeneration();

            originalUniverse.Verify(u => u.EmptyClone());
            originalUniverse.Verify(u => u.GetState(spaceLimits.SmallSpace[0]));
            nextUniverse.Verify(u => u.SetState(spaceLimits.SmallSpace[0], It.IsAny<CellState>()));
            originalUniverse.Verify(u => u.GetState(spaceLimits.SmallSpace[1]));
            nextUniverse.Verify(u => u.SetState(spaceLimits.SmallSpace[1], It.IsAny<CellState>()));
        }
    }

    public class TestingSpaceLimits : ISpaceLimits<CartesianPosition>
    {
        public List<CartesianPosition> SmallSpace = new List<CartesianPosition>{ new CartesianPosition(0,0), new CartesianPosition(0 ,1) };
        public IEnumerator<CartesianPosition> GetEnumerator()
        {
            return SmallSpace.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
