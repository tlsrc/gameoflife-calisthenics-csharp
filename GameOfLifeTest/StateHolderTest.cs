using GameOfLife;
using GameOfLife.Space;
using GameOfLife.State;
using GameOfLife.Transition;
using Moq;
using Xunit;

namespace GameOfLifeTest
{
    public class StateHolderTest
    {
        [Fact]
        public void TheUniverseHoldsCellStates()
        {
            var aPosition = new Mock<IPosition>();
            var anotherPosition = new Mock<IPosition>();
            var universe = new StateHolder();

            universe.SetState(aPosition.Object, new Alive());
            universe.SetState(anotherPosition.Object, new Dead());

            Assert.Equal(new Alive(), universe.GetState(aPosition.Object));
            Assert.Equal(new Dead(), universe.GetState(anotherPosition.Object));
        }

        [Fact]
        public void SettingCellStateIsIdempotent()
        {
            var aPosition = new Mock<IPosition>();
            var universe = new StateHolder();

            universe.SetState(aPosition.Object, new Alive());
            Assert.Equal(new Alive(), universe.GetState(aPosition.Object));

            universe.SetState(aPosition.Object, new Alive());
            Assert.Equal(new Alive(), universe.GetState(aPosition.Object));
        }

        [Fact]
        public void AStateNotSetMeansDead()
        {
            var aPosition = new Mock<IPosition>();
            var universe = new StateHolder();

            Assert.Equal(new Dead(), universe.GetState(aPosition.Object));
        }

        public void EmptyCloneCreatesANewEmptyUniverse()
        {
            var universe = new StateHolder();
            var aPosition = new Mock<IPosition>();
            universe.SetState(aPosition.Object, new Alive());

            var newUniverse = universe.EmptyClone();

            Assert.NotSame(newUniverse, universe);
            Assert.Equal(new Dead(), newUniverse.GetState(aPosition.Object));
        }
    }
}
