using AdventOfCode.Shared.Intf;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class SolveDay07 : ISolve
    {
        public string[] Input { get; set; }

        public SolveDay07()
        {
            Input = File.ReadAllLines("Inputs/Day02.txt");
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