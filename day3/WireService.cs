using System;
using System.Linq;
using System.Collections.Generic;

namespace day3
{
    class WireService
    {
        private readonly CoordinateEqualityComparer _coordinateEqualityComparer = new CoordinateEqualityComparer();

        public IEnumerable<PathInstruction> ParseInstructions(string pathString)
            => pathString
                .Split(',')
                .Select(ParseInstruction);

        public IEnumerable<WireSegment> InterpretInstructions(IEnumerable<PathInstruction> pathSegments)
        {
            int xFrom = 0,
                yFrom = 0,
                xTo = 0,
                yTo = 0,
                previousDist = 0;

            foreach (var segment in pathSegments)
            {
                switch (segment.Direction)
                {
                    case Direction.Up:
                        yFrom += 1;
                        yTo = yFrom + (segment.Length - 1);
                        break;
                    case Direction.Right:
                        xFrom += 1;
                        xTo = xFrom + (segment.Length - 1);
                        break;
                    case Direction.Down:
                        yFrom -= 1;
                        yTo = yFrom - (segment.Length - 1);
                        break;
                    case Direction.Left:
                        xFrom -= 1;
                        xTo = xFrom - (segment.Length - 1);
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                yield return new WireSegment(xFrom, yFrom, xTo, yTo, previousDist);

                previousDist += segment.Length;
                xFrom = xTo;
                yFrom = yTo;
            }
        }

        public bool GetAreParallel(WireSegment s1, WireSegment s2)
            => s1.Orientation == s2.Orientation;

        public bool GetHasIntersection(WireSegment s1, WireSegment s2)
        {
            if (GetAreParallel(s1, s2))
            {
                return false;
            }

            switch (s1.Orientation)
            {
                case Orientation.Horizontal:
                    return GetIsBetween(s1.From.X, s1.To.X, s2.From.X)
                        && GetIsBetween(s2.From.Y, s2.To.Y, s1.From.Y);

                case Orientation.Vertical:
                    return GetIsBetween(s2.From.X, s2.To.X, s1.From.X)
                        && GetIsBetween(s1.From.Y, s1.To.Y, s2.From.Y);

                default:
                    throw new InvalidOperationException();
            }
        }

        public bool GetIsBetween(int from, int to, int c)
        {
            if (from < to)
            {
                return from <= c && c <= to;
            }
            else if (from > to)
            {
                return to <= c && c <= from;
            }
            else
            {
                return c == from;
            }
        }

        public IEnumerable<Intersection> GetIntersections(WireSegment s1, WireSegment s2)
        {
            if (GetAreParallel(s1, s2))
            {
                return Enumerable.Empty<Intersection>();
            }

            return from c1 in s1.EnumerateConstitutentCoordinates()
                   from c2 in s2.EnumerateConstitutentCoordinates()
                   where _coordinateEqualityComparer.Equals(c1.Coordinate, c2.Coordinate)
                   select new Intersection(c1.Coordinate, c1.WireDist, c2.WireDist);
        }

        private PathInstruction ParseInstruction(string instructionString)
        {
            Direction direction;

            switch (instructionString[0])
            {
                case 'U':
                    direction = Direction.Up;
                    break;
                case 'R':
                    direction = Direction.Right;
                    break;
                case 'D':
                    direction = Direction.Down;
                    break;
                case 'L':
                    direction = Direction.Left;
                    break;
                default:
                    throw new ArgumentException();
            }

            var length = int.Parse(instructionString.Substring(1));

            return new PathInstruction(direction, length);
        }
    }
}
