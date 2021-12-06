using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day12
{
    public class Instruction
    {
        public char Action { get; set; }
        public int Value { get; set; }

        public Instruction(char action, int value)
        {
            Action = action;
            Value = value;
        }
    }
}
