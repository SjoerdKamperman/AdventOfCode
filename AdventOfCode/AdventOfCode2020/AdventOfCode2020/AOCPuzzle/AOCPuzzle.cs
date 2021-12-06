using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public abstract class AOCPuzzle
    {
        public string[] Input { get; set; }

        public AOCPuzzle(string path, int day)
        {
            Input = System.IO.File.ReadAllLines(string.Format(path, day));
        }

        public abstract void SolveOne();
        public abstract void SolveTwo();
    }
}
