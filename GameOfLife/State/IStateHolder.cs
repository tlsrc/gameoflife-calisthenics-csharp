using GameOfLife.Space;

namespace GameOfLife.State
{
    public interface IStateHolder
    {
        void SetState(IPosition aPosition, CellState itsState);
        CellState GetState(IPosition aPosition);
        IStateHolder EmptyClone();
    }
}