using System.Collections.Generic;

namespace GameOfLife.Space
{
    public interface ISpaceLimits<out T> : IEnumerable<T> where T : IPosition
    {
    }
}
