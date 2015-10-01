using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.State;
using GameOfLife.Transition;

namespace GameOfLife.Space
{
    public class CartesianPosition : IPosition
    {
        private readonly int _x;
        private readonly int _y;

        public CartesianPosition(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((CartesianPosition) obj)._x == _x && ((CartesianPosition) obj)._y == _y;
        }

        public override int GetHashCode()
        {
            return _x;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})",_x, _y);
        }

        private CartesianPosition TopRight()    { return new CartesianPosition(_x + 1, _y + 1); }
        private CartesianPosition Right()       { return new CartesianPosition(_x + 1, _y); }
        private CartesianPosition BottomRight() { return new CartesianPosition(_x + 1, _y - 1); }
        private CartesianPosition Top()         { return new CartesianPosition(_x, _y + 1); }
        private CartesianPosition Bottom()      { return new CartesianPosition(_x, _y - 1); }
        private CartesianPosition TopLeft()     { return new CartesianPosition(_x - 1, _y + 1); }
        private CartesianPosition Left()        { return new CartesianPosition(_x - 1, _y); }
        private CartesianPosition BottomLeft()  { return new CartesianPosition(_x - 1, _y - 1); }

        public AliveNeighborsCount CountAliveNeighbors(IStateHolder stateHolder)
        {
            var neighborsStates = new List<CellState>
            {
                stateHolder.GetState(TopLeft()), stateHolder.GetState(Top()), stateHolder.GetState(TopRight()),
                stateHolder.GetState(Left()), stateHolder.GetState(Right()),
                stateHolder.GetState(BottomLeft()), stateHolder.GetState(Bottom()), stateHolder.GetState(BottomRight()),
            };
            var aliveOnes = neighborsStates.Where(s => s.Equals(new Alive()));
            return new AliveNeighborsCount(aliveOnes.Count());
        }
    }
}