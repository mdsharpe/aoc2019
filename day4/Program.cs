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

            var result = Enumerable.Range(rangeStart, (rangeEnd - rangeStart) + 1)
                .Where(o => TwoAdjacentDigitsTheSame(o))
                .Where(o => !DigitsDecrease(o))
                .Count();

            Console.WriteLine(result);
        }

        private static bool TwoAdjacentDigitsTheSame(int n)
        {
            var s = n.ToString();

            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    return true;
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
