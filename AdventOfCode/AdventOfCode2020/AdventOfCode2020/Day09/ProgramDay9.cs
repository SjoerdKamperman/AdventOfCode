using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day9
{
    public class ProgramDay9
    {
        public long[] Input { get; set; }
        public int StartIndex { get; set; } = 0;
        public int Preamble { get; set; }

        public ProgramDay9(string path, int preamble)
        {
            var stringInput = System.IO.File.ReadAllLines(path);
            Input = Array.ConvertAll(stringInput, x => long.Parse(x));
            Preamble = preamble;
        }

        public void ExecuteProgramOne()
        {
            var numberIsValid = true;
            while(numberIsValid)
            {
                numberIsValid = IsValidNumber();
            }
            Console.WriteLine($"Invalid number is { Input[StartIndex + Preamble] }");
            var result = GetEncyptionWeakness(Input[StartIndex + Preamble]);
            var sum = result.First() + result.Last();
            Console.WriteLine($"Smallest number is { result.First() } and Largest number = { result.Last() } results into { sum } ");
        }

        private bool IsValidNumber()
        {
            var currentPosition = StartIndex + Preamble;
            for (int i = StartIndex; i < currentPosition; i++)
            {
                for (int j = StartIndex+1; j < currentPosition-1; j++)
                {
                    var sum = Input[i] + Input[j];
                    if (sum == Input[currentPosition])
                    {
                        StartIndex++;
                        return true;
                    }
                }                
            }
            return false;
        }

        private List<long> GetEncyptionWeakness(long input)
        {
            var sum = new List<long>();
            for (int i = 0; i < Input.Length; i++)
            {
                var currentTotal = 0L;
                var counter = i;
                var temp = new List<long>();
                while (currentTotal < input)
                {
                    currentTotal += Input[counter];
                    temp.Add(Input[counter]);
                    counter++;
                }
                if (currentTotal == input)
                {
                    temp.Sort();
                    return temp;
                }
            }

            return sum;
        }
    }
}
