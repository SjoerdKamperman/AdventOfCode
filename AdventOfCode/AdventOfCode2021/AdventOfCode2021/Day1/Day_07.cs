using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2021
{
    public class Day_07 : BaseDay
    {
        public string[] Input { get; set; }

        public Day_07()
        {
            Input = System.IO.File.ReadAllLines(InputFilePath);
        }

        public new void Solve_One()
        {
            var array = ParseInputToDoubleArray();
            var median = CalculateMedian(array);
            var result = Math.Round(median);
            double final = 0d;
            foreach (var item in array)
            {
                var diff = item - result;
                final += Math.Abs(diff);
            }
            Result = final.ToString();
            base.Solve_One();
        }

        public new void Solve_Two()
        {   
            var input = ParseInputToDoubleArray();
            Result =  Enumerable.Range(1, (int)input.Max())
            .Select(i =>
                (i, input.Sum(n => Math.Abs(i - n) * (Math.Abs(i - n) + 1) / 2)))
            .ToDictionary(i => i.Item1)
            .Min(k => k.Value.Item2)
            .ToString();
            base.Solve_One();
        }

        private double[] ParseInputToDoubleArray()
        {
            var input = Input[0].Split(',');
            var result = input.Select(x => double.Parse(x)).ToArray();
            return result;
        }

        private double CalculateMedian(double[] input)
        {
            double[] sortedPNumbers = (double[])input.Clone();
            Array.Sort(sortedPNumbers);

            //get the median
            int size = sortedPNumbers.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)sortedPNumbers[mid] : ((double)sortedPNumbers[mid] + (double)sortedPNumbers[mid - 1]) / 2;
            return median;
        }

        private double CalculateAverage(double[] input)
        {
            return Queryable.Average(input.AsQueryable());
        }
    }
}
