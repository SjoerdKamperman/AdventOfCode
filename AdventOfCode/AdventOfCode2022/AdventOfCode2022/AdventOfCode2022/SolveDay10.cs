using AdventOfCode.Shared.Intf;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class SolveDay10 : ISolve
    {
        public string[] Input { get; set; }

        public SolveDay10()
        {
            Input = File.ReadAllLines("Inputs/Day09.txt");
        }

        public void SolvePartOne()
        {
            Console.WriteLine("SolveOne");
        }

        public void SolvePartTwo()
        {
            Console.WriteLine("SolveTwo");
        }
    }
}