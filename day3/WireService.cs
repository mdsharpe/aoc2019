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
            int x = 0, y = 0;

            foreach (var segment in pathSegments)
            {
                int x1 = x, y1 = y;

                switch (segment.Direction)
                {
                    case Direction.Up:
                        y -= segment.Length;
                        break;
                    case Direction.Right:
                        x += segment.Length;
                        break;
                    case Direction.Down:
                        y += segment.Length;
                        break;
                    case Direction.Left:
                        x -= segment.Length;
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                int x2 = x, y2 = y;

                yield return new WireSegment(x1, y1, x2, y2);
            }
        }

        public IEnumerable<Coordinate> GetIntersections(WireSegment s1, WireSegment s2)
        {
            return from c1 in s1.EnumerateConstitutentCoordinates()
                   from c2 in s2.EnumerateConstitutentCoordinates()
                   where _coordinateEqualityComparer.Equals(c1, c2)
                   select c1;
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
