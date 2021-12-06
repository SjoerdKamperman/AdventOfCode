using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day12
{
    public class ProgramDay12
    {
        public string[] Input { get; set; }

        public ProgramDay12(string path)
        {
            Input = System.IO.File.ReadAllLines(path);
        }

        public void Solve()
        {
            var instructions = GetInstructions();
            var ship = new Ship();

            foreach (var instruction in instructions)
            {
                ship.ExecuteInstruction(instruction);
            }
            var x = Math.Abs(ship.X);
            var y = Math.Abs(ship.Y);
            Console.WriteLine($"Position = {x} + {y} = {x + y}");

        }

        private List<Instruction> GetInstructions()
        {
            var instructions = new List<Instruction>();
            foreach (var line in Input)
            {
                var action = line[0];
                var value = int.Parse(line.Substring(1));
                instructions.Add(new Instruction(action, value));
            }
            return instructions;
        }
    }
}
