using System;
using System.Collections.Generic;
using System.Linq;

namespace day3
{
    class WireSegment
    {
        public WireSegment(int x1, int y1, int x2, int y2)
        {
            From = new Coordinate(x1, y1);
            To = new Coordinate(x2, y2);
        }

        public Coordinate From { get; }
        public Coordinate To { get; }

        public IEnumerable<Coordinate> EnumerateConstitutentCoordinates()
        {
            if (From.X == To.X)
            {
                return Enumerable.Range(
                    Math.Min(From.Y, To.Y),
                    Math.Max(From.Y, To.Y) - Math.Min(From.Y, To.Y))
                    .Select(y => new Coordinate(From.X, y));
            }
            else if (From.Y == To.Y)
            {
                return Enumerable.Range(
                    Math.Min(From.X, To.X),
                    Math.Max(From.X, To.X) - Math.Min(From.X, To.X))
                    .Select(x => new Coordinate(x, From.Y));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}