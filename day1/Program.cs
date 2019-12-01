using System;
using System.IO;
using System.Linq;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                File.ReadAllLines(args[0])
                    .Select(o => int.Parse(o))
                    .Select(CalculateFuel)
                    .Sum()
            );
        }

        private static int CalculateFuel(int mass)
            => (int)Math.Floor((decimal)mass / 3) - 2;
    }
}
