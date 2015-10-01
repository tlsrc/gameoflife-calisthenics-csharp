using System.Collections;
using System.Collections.Generic;

namespace GameOfLife.Space
{
    public class CartesianSpaceLimits : ISpaceLimits<CartesianPosition>
    {
        public const int MAX = 5;
        private readonly IList<CartesianPosition> _allPositions = new List<CartesianPosition>();

        public CartesianSpaceLimits()
        {
            FillSpace();
        }

        private void FillSpace()
        {
            for (var y = MAX; y >=- 0; y--)
            {
                FillLine(y);
            }
        }

        private void FillLine(int y)
        {
            for (var x = 0; x <= MAX; x++)
            {
                _allPositions.Add(new CartesianPosition(x, y));
            }
        }

        public IEnumerator<CartesianPosition> GetEnumerator()
        {
            return _allPositions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
