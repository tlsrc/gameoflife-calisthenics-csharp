using GameOfLife.Transition;

namespace GameOfLife.State
{
    public class Dead : CellState
    {
        private static readonly AliveNeighborsCount TO_BECOME_ALIVE = new AliveNeighborsCount(3);

        public Dead() : base("dead")
        {
        }

        public override CellState Evolve(AliveNeighborsCount aliveNeighborsCount)
        {
            if (aliveNeighborsCount.Equals(TO_BECOME_ALIVE))
            {
                return new Alive();
            }
            return new Dead();
        }
    }
}