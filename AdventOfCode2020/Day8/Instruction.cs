using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day8
{
    public class Instruction
    {
        public int Position { get; set; }
        public string Operation { get; set; }
        public int Argument { get; set; }
        public bool Executed { get; set; } = false;
        public bool Changed { get; set; } = false;

        public Instruction(int position, string operation, int argument)
        {
            Position = position;
            Operation = operation;
            Argument = argument;
        }
    }
}
