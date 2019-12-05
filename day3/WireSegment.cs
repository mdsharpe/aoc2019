using System;
using System.Collections.Generic;
using System.Linq;

namespace day3
{
    class WireSegment
    {
        public WireSegment(int xFrom, int yFrom, int xTo, int yTo, int previousDist)
        {
            From = new Coordinate(xFrom, yFrom);
            To = new Coordinate(xTo, yTo);
            PreviousDist = previousDist;
        }

        public Coordinate From { get; }
        public Coordinate To { get; }
        public int PreviousDist { get; }

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
                var range = From.Y < To.Y
                    ? Enumerable.Range(From.Y, (To.Y - From.Y) + 1)
                    : Enumerable.Range(To.Y, (From.Y - To.Y) + 1).Reverse();

                return range
                    .Select((y, i) => new CoordinateOnWire(
                        new Coordinate(From.X, y),
                        PreviousDist + (i + 1)
                    ));
            }
            else if (From.Y == To.Y)
            {
                var range = From.X < To.X
                    ? Enumerable.Range(From.X, (To.X - From.X) + 1)
                    : Enumerable.Range(To.X, (From.X - To.X) + 1).Reverse();

                return range
                    .Select((x, i) => new CoordinateOnWire(
                        new Coordinate(x, From.Y),
                        PreviousDist + (i + 1)
                    ));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}