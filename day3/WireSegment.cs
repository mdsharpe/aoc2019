using System;
using System.Collections.Generic;
using System.Linq;

namespace day3
{
    class WireSegment
    {
        public WireSegment(int xFrom, int yFrom, int xTo, int yTo, int startLength)
        {
            From = new Coordinate(xFrom, yFrom);
            To = new Coordinate(xTo, yTo);
            StartLength = startLength;
        }

        public Coordinate From { get; }
        public Coordinate To { get; }
        public int StartLength { get; }

        public Orientation Orientation
        {
            get
            {
                if (From.Y == To.Y)
                {
                    return Orientation.Horizontal;
                }
                else if (From.X == To.X)
                {
                    return Orientation.Vertical;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public IEnumerable<CoordinateOnWire> EnumerateConstitutentCoordinates()
        {
            if (From.X == To.X)
            {
                return Enumerable.Range(
                    Math.Min(From.Y, To.Y),
                    Math.Max(From.Y, To.Y) - Math.Min(From.Y, To.Y))
                    .Select((y, i) => new CoordinateOnWire(
                        new Coordinate(From.X, y),
                        StartLength + i
                    ));
            }
            else if (From.Y == To.Y)
            {
                return Enumerable.Range(
                    Math.Min(From.X, To.X),
                    Math.Max(From.X, To.X) - Math.Min(From.X, To.X))
                    .Select((x, i) => new CoordinateOnWire(
                        new Coordinate(x, From.Y),
                        StartLength + i
                    ));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}