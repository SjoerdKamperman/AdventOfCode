using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    public class Day_06 : BaseDay
    {
        public string[] Input { get; set; }

        public Day_06()
        {
            Input = System.IO.File.ReadAllLines(InputFilePath);
        }

        public new void Solve_One()
        {
            long[] ages = new long[9];
            var values = ParseInputToLongArray();
            foreach (long value in values) ages[value]++;

            for (int i = 0; i < 80; i++)
            {
                long last = ages[0];
                for (int j = 0; j < 8; j++) ages[j] = ages[j + 1];
                ages[6] += last;
                ages[8] = last;
            }

            Result = ages.Sum().ToString();
            base.Solve_One();
        }

        public new void Solve_Two()
        {
            long[] ages = new long[9];
            var values = ParseInputToLongArray();
            foreach (long value in values) ages[value]++;

            for (int i = 0; i < 256; i++)
            {
                long last = ages[0];
                for (int j = 0; j < 8; j++) ages[j] = ages[j + 1];
                ages[6] += last;
                ages[8] = last;
            }

            Result = ages.Sum().ToString();
            base.Solve_Two();
        }

        private long[] ParseInputToLongArray()
        {
            var input = Input[0].Split(',');
            var result = input.Select(x => long.Parse(x)).ToArray();
            return result;
        }
    }
}
