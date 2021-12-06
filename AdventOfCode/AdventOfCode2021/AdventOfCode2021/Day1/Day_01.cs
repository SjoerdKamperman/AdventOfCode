using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day_01 : BaseDay
    {
        public string[] Input { get; set; }

        public Day_01()
        {
            Input = System.IO.File.ReadAllLines(InputFilePath);
        }

        public new void Solve_One()
        {
            var array = ParseInputToIntArray();
            Solve_One(array);
        }

        private void Solve_One(int[] input)
        {
            
            var increaseCounter = 0;
            int previous = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                int current = input[i];
                if (current > previous)
                    increaseCounter++;

                previous = current;
            }

            Console.WriteLine(increaseCounter);
        }

        public new void Solve_Two()
        {
            var array = ParseInputToIntArray();
            int[] listOfSums = new int[Input.Length - 2];
            for (int i = 0; i < array.Length-2; i ++)
            {
                var result = array[i] + array[i+1] + array[i+2];
                listOfSums[i] = result;
            }
            Solve_One(listOfSums);
        }

        private int[] ParseInputToIntArray()
        {
            var result = Input.Select(x => int.Parse(x)).ToArray();
            return result;
        }
    }
}
