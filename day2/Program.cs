using System;
using System.IO;
using System.Linq;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                File.ReadAllText(args[0])
                    .Select(ParseInstructions);
            );
        }

        private static Instruction[] ParseInstructions(string input){
            var nums = input.Split(',').Select(o => int.Parse(o));
            
        }
    }
}
