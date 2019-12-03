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

            WriteOutput(program, 12, 02);
            FindInput(program, 19690720);
        }

        private static void WriteOutput(int[] program, int input1, int input2)
        {
            Console.WriteLine($"{input1 * 100 + input2} => {Run(program, input1, input2)[0]}");
        }

        private static void FindInput(int[] program, int output)
        {
            for (var input1 = 0; input1 < 100; input1++)
            {
                for (var input2 = 0; input2 < 100; input2++)
                {
                    var result = Run(program, input1, input2)[0];
                    if (result == output)
                    {
                        Console.WriteLine($"{input1 * 100 + input2} => {output}");
                        return;
                    }
                }
            }
        }

        private static int[] Run(IEnumerable<int> programEnumerable, int input1, int input2)
        {
            var program = programEnumerable.ToArray();

            program[1] = input1;
            program[2] = input2;

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

            return program;
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
