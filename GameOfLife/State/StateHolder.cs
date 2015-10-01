using System.Collections.Generic;
using GameOfLife.Space;

namespace GameOfLife.State
{
    public class StateHolder : IStateHolder
    {
        private readonly IDictionary<IPosition, CellState> _states = new Dictionary<IPosition, CellState>();

        public void SetState(IPosition aPosition, CellState itsState)
        {
            if (_states.ContainsKey(aPosition))
            {
                _states[aPosition] = itsState;
                return;
            }
            _states.Add(aPosition, itsState);
        }

        public CellState GetState(IPosition aPosition)
        {
            if (_states.ContainsKey(aPosition))
            {
                return _states[aPosition];
            }
            return new Dead();
        }

        public IStateHolder EmptyClone()
        {
            return new StateHolder();
        }
    }
}