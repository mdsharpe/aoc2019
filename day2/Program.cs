using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = File.ReadAllText(args[0])
                .Split(',')
                .Select(o => int.Parse(o))
                .ToArray();

            // 1202
            program[1] = 12;
            program[2] = 2;

            foreach (var instruction in ParseInstructions(program))
            {
                if (instruction.Opcode == Opcode.Halt)
                {
                    break;
                }

                var num1 = program[instruction.PosIn1];
                var num2 = program[instruction.PosIn2];

                switch (instruction.Opcode)
                {
                    case Opcode.Add:
                        program[instruction.PosOut] = num1 + num2;
                        break;
                    case Opcode.Multiply:
                        program[instruction.PosOut] = num1 * num2;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Console.WriteLine(string.Join(',', program));
        }

        private static IEnumerable<Instruction> ParseInstructions(int[] program)
        {
            if (program.Length < 1)
            {
                yield break;
            }

            var i = 0;

            do
            {
                var opcode = (Opcode)program[i];

                if (opcode == Opcode.Halt || !Enum.IsDefined(typeof(Opcode), opcode))
                {
                    break;
                }

                yield return new Instruction(
                    opcode,
                    program[i + 1],
                    program[i + 2],
                    program[i + 3]);

                i += 4;
            } while (i < program.Length);
        }
    }
}
