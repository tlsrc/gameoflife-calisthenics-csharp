using GameOfLife.Transition;

namespace GameOfLife.State
{
    public abstract class CellState
    {
        protected readonly string State;

        protected CellState(string state)
        {
            State = state;
        }

        public abstract CellState Evolve(AliveNeighborsCount aliveNeighborsCount);

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return ((CellState)obj).State == State;
        }

        public override int GetHashCode()
        {
            return State.Length;
        }

        public override string ToString()
        {
            return State;
        }
    }

}