using GameOfLife;
using GameOfLife.Space;
using GameOfLife.State;
using GameOfLife.Transition;
using Moq;
using Xunit;

namespace GameOfLifeTest
{
    public class CartesianPositionTest
    {
        [Fact]
        public void AsksTheUniverseForAliveNeighborsCount()
        {
            var stateHolder = new Mock<IStateHolder>();
            stateHolder.Setup(sh => sh.GetState(It.IsAny<IPosition>())).Returns(new Alive());
            var position = new CartesianPosition(0,0);

            var count = position.CountAliveNeighbors(stateHolder.Object);

            stateHolder.Verify(sh => sh.GetState(new CartesianPosition(-1, -1)));
            stateHolder.Verify(sh => sh.GetState(new CartesianPosition(-1, 0)));
            stateHolder.Verify(sh => sh.GetState(new CartesianPosition(-1, 1)));
            stateHolder.Verify(sh => sh.GetState(new CartesianPosition(0, -1)));
            stateHolder.Verify(sh => sh.GetState(new CartesianPosition(0, 1)));
            stateHolder.Verify(sh => sh.GetState(new CartesianPosition(1, -1)));
            stateHolder.Verify(sh => sh.GetState(new CartesianPosition(1, 0)));
            stateHolder.Verify(sh => sh.GetState(new CartesianPosition(1, 1)));
            Assert.Equal(new AliveNeighborsCount(8), count);
        }

        [Fact]
        public void NoNeighborsAreAliveIfEmptyUniverse()
        {
            var stateHolder = new Mock<IStateHolder>();
            stateHolder.Setup(sh => sh.GetState(It.IsAny<IPosition>())).Returns(new Dead());
            var position = new CartesianPosition(0, 0);

            var count = position.CountAliveNeighbors(stateHolder.Object);

            Assert.Equal(new AliveNeighborsCount(0), count);
        }

    }
}
