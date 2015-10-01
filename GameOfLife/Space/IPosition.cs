using GameOfLife.State;
using GameOfLife.Transition;

namespace GameOfLife.Space
{
    public interface IPosition
    {
        AliveNeighborsCount CountAliveNeighbors(IStateHolder stateHolder);
    }
}