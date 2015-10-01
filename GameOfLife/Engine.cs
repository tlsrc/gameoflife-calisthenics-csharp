using System;
using System.Text;
using GameOfLife.Space;
using GameOfLife.State;

namespace GameOfLife
{
    public class Engine<T> where T : IPosition
    {
        private IStateHolder _currentStateHolder;
        private readonly ISpaceLimits<T> _spaceLimits;

        public Engine(IStateHolder stateHolder, ISpaceLimits<T> spaceLimits)
        {
            _currentStateHolder = stateHolder;
            _spaceLimits = spaceLimits;
        }

        public IStateHolder NextGeneration()
        {
            var nextStateHolder = _currentStateHolder.EmptyClone();
            foreach (var aPosition in _spaceLimits)
            {
                nextStateHolder.SetState(aPosition, NextGenerationAt(aPosition));    
            }
            _currentStateHolder = nextStateHolder;
            return nextStateHolder;
        }

        private CellState NextGenerationAt(T aPosition)
        {
            var currentState = _currentStateHolder.GetState(aPosition);
            var aliveNeighbors = aPosition.CountAliveNeighbors(_currentStateHolder);
            var transition = new Transition.Transition(currentState, aliveNeighbors);
            return transition.Execute();
        }
    }
}