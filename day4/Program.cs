using System;
using System.Linq;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeStart = int.Parse(args[0]),
                rangeEnd = int.Parse(args[1]);

            var range = Enumerable.Range(rangeStart, (rangeEnd - rangeStart) + 1);

            var part1Possibilities = range
                .Where(o => HasAdjacentDigits(o))
                .Where(o => !DigitsDecrease(o));

            var part1Result = part1Possibilities.Count();

            Console.WriteLine($"Part 1 result: {part1Result}");

            var part2Possibilities = range
                .Where(o => HasAdjacentDigits(o, 2))
                .Where(o => !DigitsDecrease(o));

            var part2Result = part2Possibilities.Count();

            Console.WriteLine($"Part 2 result: {part2Result}");
        }

        private static bool HasAdjacentDigits(int n, int? requiredSequenceLength = null)
        {
            var s = n.ToString();
            var sequenceLength = 1;

            for (var i = 1; i < s.Length; i++)
            {
                var isSameAsPrevious = s[i] == s[i - 1];

                if (isSameAsPrevious)
                {
                    sequenceLength++;
                }

                if (sequenceLength > 1)
                {
                    if (requiredSequenceLength.HasValue)
                    {
                        if ((!isSameAsPrevious || i == s.Length - 1) && sequenceLength == requiredSequenceLength.Value)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }

                if (!isSameAsPrevious)
                {
                    sequenceLength = 1;
                }
            }

            return false;
        }

        private static bool DigitsDecrease(int n)
        {
            var s = n.ToString();

            for (var i = 1; i < s.Length; i++)
            {
                if (int.Parse(s[i].ToString()) < int.Parse(s[i - 1].ToString()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
