using System;
using System.Collections.Generic;

namespace day3 {
    class CoordinateComparer : IComparer<Coordinate> {
        public int Compare(Coordinate c1, Coordinate c2) {
            if (c1 == null || c2 == null) {
                throw new ArgumentNullException();
            }

            if (object.ReferenceEquals(c1, c2)) {
                return 0;
            }

            return (Math.Abs(c2.X) - Math.Abs(c1.X)) + (Math.Abs(c2.Y) - Math.Abs(c1.Y));
        }
    }
}