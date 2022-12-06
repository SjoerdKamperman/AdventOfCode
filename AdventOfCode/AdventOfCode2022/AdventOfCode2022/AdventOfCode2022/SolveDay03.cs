using AdventOfCode.Shared.Intf;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class SolveDay03 : ISolve
    {
        public string[] Input { get; set; }

        public SolveDay03()
        {
            Input = File.ReadAllLines("Inputs/Day03.txt");
        }

        public void SolvePartOne()
        {
            var result = Input
                .Select(x => GetPriority(x.Take(x.Length / 2)
                .Intersect(x.Skip(x.Length / 2)).Single()))
                .Sum();

            Console.WriteLine(result);
        }

        public void SolvePartTwo()
        {
            var result = Input
                .Chunk(3).Select(x => GetPriority(x[0].Intersect(x[1])
                .Intersect(x[2]).Single()))
                .Sum();

            Console.WriteLine(result);
        }

        private int GetPriority(char type)
        {
            var number = (int)type;

            return number > 96 ? number - 96 : number - 38;
        }
    }
}