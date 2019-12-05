using System;
using System.Linq;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new WireService();

            var wires = System.IO.File.ReadAllLines(args[0])
                .Select(o =>
                    service.InterpretInstructions(
                        service.ParseInstructions(o)))
                .ToArray();

            var centralPort = new Coordinate(0, 0);
            var equalityComparer = new CoordinateEqualityComparer();
            var manhattanComparer = new CoordinateManhattanComparer();

            var intersections = (from s1 in wires[0]
                                 from s2 in wires[1]
                                 where service.GetHasIntersection(s1, s2)
                                 from i in service.GetIntersections(s1, s2)
                                 where !equalityComparer.Equals(centralPort, i.Coordinate)
                                 select i).ToArray();

            var closestByManhattan = (from i in intersections
                                      let md = Math.Abs(manhattanComparer.Compare(centralPort, i.Coordinate))
                                      orderby md
                                      select new
                                      {
                                          X = i.Coordinate.X,
                                          Y = i.Coordinate.Y,
                                          Md = md
                                      }).First();

            Console.WriteLine($"{closestByManhattan.X}, {closestByManhattan.Y} - distance {closestByManhattan.Md}.");

            var closestByWireDist = (from i in intersections
                                     orderby i.TotalWireDist
                                     select new
                                     {
                                         X = i.Coordinate.X,
                                         Y = i.Coordinate.Y,
                                         TotalWireDist = i.TotalWireDist
                                     }).First();

            Console.WriteLine($"{closestByWireDist.X}, {closestByWireDist.Y} - distance {closestByWireDist.TotalWireDist}.");
        }
    }
}
