using System;
using System.Collections.Generic;

namespace day3
{
    class CoordinateEqualityComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate c1, Coordinate c2)
        {
            if (c1 == null || c2 == null)
            {
                return false;
            }

            if (object.ReferenceEquals(c1, c2))
            {
                return true;
            }

            return c1.X == c2.X && c1.Y == c2.Y;
        }

        public int GetHashCode(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }
    }
}