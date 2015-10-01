using System;
using System.Linq;
using GameOfLife;
using GameOfLife.Space;
using GameOfLife.State;
using Xunit;
using Xunit.Abstractions;

namespace GameOfLifeTest
{
    public class AcceptanceTests
    {
        private readonly ITestOutputHelper _output;

        public AcceptanceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void FourAliveCellsStayAlive()
        {
            var p00 = new CartesianPosition(0, 0);
            var p01 = new CartesianPosition(0, 1);
            var p11 = new CartesianPosition(1, 1);
            var p10 = new CartesianPosition(1, 0);

            var stateHolder = new StateHolder();
            stateHolder.SetState(p00, new Alive());
            stateHolder.SetState(p01, new Alive());
            stateHolder.SetState(p11, new Alive());
            stateHolder.SetState(p10, new Alive());

            var engine = new Engine<CartesianPosition>(stateHolder, new CartesianSpaceLimits());
            var secondGeneration = engine.NextGeneration();

            Assert.Equal(new Alive(), stateHolder.GetState(p00));
            Assert.Equal(new Alive(), stateHolder.GetState(p01));
            Assert.Equal(new Alive(), stateHolder.GetState(p11));
            Assert.Equal(new Alive(), stateHolder.GetState(p10));
        }

        [Fact]
        public void ThreeAliveCellsRotate()
        {
            
            var p11 = new CartesianPosition(1, 1);
            var p12 = new CartesianPosition(1, 2);
            var p13 = new CartesianPosition(1, 3);

            var stateHolder = new StateHolder();
            stateHolder.SetState(p11, new Alive());
            stateHolder.SetState(p12, new Alive());
            stateHolder.SetState(p13, new Alive());

            var engine = new Engine<CartesianPosition>(stateHolder, new CartesianSpaceLimits());
            var secondGeneration = engine.NextGeneration();
            Assert.Equal(new Dead(), secondGeneration.GetState(p11));
            Assert.Equal(new Alive(), secondGeneration.GetState(p12));
            Assert.Equal(new Dead(), secondGeneration.GetState(p13));

            var thirdGeneration = engine.NextGeneration();
            Assert.Equal(new Alive(), thirdGeneration.GetState(p11));
            Assert.Equal(new Alive(), thirdGeneration.GetState(p12));
            Assert.Equal(new Alive(), thirdGeneration.GetState(p13));
        }

    }
}
