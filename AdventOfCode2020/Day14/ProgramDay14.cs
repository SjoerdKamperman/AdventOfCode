using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day14
{
    public class ProgramDay14
    {
        public string[] Input { get; set; }

        public ProgramDay14(string path, int day)
        {
            Input = System.IO.File.ReadAllLines(string.Format(path, day));
        }

        public void SolveOne()
        {
            Console.WriteLine($"First Answers is: ");
        }
    }
}
