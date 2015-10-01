using System;
using GameOfLife.State;

namespace GameOfLife.Transition
{
    public class Transition
    {
        private readonly CellState _cellState;
        private readonly AliveNeighborsCount _aliveNeighborsCount;

        public Transition(CellState cellState, AliveNeighborsCount aliveNeighborsCount)
        {
            _cellState = cellState;
            _aliveNeighborsCount = aliveNeighborsCount;
        }

        public CellState Execute()
        {
            return _cellState.Evolve(_aliveNeighborsCount);
        }

        public override string ToString()
        {
            return String.Format("{0} with {1}", _cellState, _aliveNeighborsCount);
        }
    }
}