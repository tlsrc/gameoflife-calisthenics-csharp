using GameOfLife.Transition;

namespace GameOfLife.State
{
    public class Alive : CellState
    {
        public Alive() : base("alive")
        {
        }

        public override CellState Evolve(AliveNeighborsCount aliveNeighborsCount)
        {
            if(aliveNeighborsCount.Equals(AliveNeighborsCount.TWO_NEIGHBORS)) return new Alive();
            if(aliveNeighborsCount.Equals(AliveNeighborsCount.THREE_NEIGHBORS)) return new Alive();
            return new Dead();
        }
    }
}