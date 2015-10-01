using System;

namespace GameOfLife.Transition
{
    public class AliveNeighborsCount
    {
        private readonly int _count;

        public AliveNeighborsCount(int count)
        {
            _count = count;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((AliveNeighborsCount) obj)._count == _count;
        }

        public override int GetHashCode()
        {
            return _count;
        }

        public override string ToString()
        {
            return String.Format("{0} alive neighbors", _count);
        }

        public static readonly AliveNeighborsCount TWO_NEIGHBORS = new AliveNeighborsCount(2);
        public static readonly AliveNeighborsCount THREE_NEIGHBORS = new AliveNeighborsCount(3);
    }
}