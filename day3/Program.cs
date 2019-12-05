﻿using System;
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
            var comparer = new CoordinateComparer();

            var intersections = from s1 in wires[0].AsParallel()
                                from s2 in wires[1]
                                where service.GetHasIntersection(s1, s2)
                                from intersection in service.GetIntersections(s1, s2)
                                orderby Math.Abs(comparer.Compare(intersection, centralPort))
                                select intersection;

            var closestIntersection = intersections.First();
            var manhattanDistance = comparer.Compare(centralPort, closestIntersection);

            Console.WriteLine($"{closestIntersection.X}, {closestIntersection.Y} - distance {manhattanDistance}.");
        }
    }
}
