using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day1
{
    public class ProgramDay1
    {
        public string[] Input { get; set; }

        public ProgramDay1(string path)
        {
            Input = System.IO.File.ReadAllLines(path); ;
        }

        public int ExecuteExpenseReportSumOfTwo()
        {
            var left = 0;
            var right = Input.Length - 1;
            var output = 2020;
            int[] intInput = Array.ConvertAll(Input, x => int.Parse(x));
            Array.Sort(intInput);

            while (left < right)
            {
                if (intInput[left] + intInput[right] == output)
                {
                    return intInput[left] * intInput[right];
                }
                else if (intInput[left] + intInput[right] < output)
                {
                    left++;
                } else
                {
                    right--;
                }
            }
            return -1;
        }

        public int ExecuteExpenseReportSumOfThree()
        {
            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 1; j < Input.Length; j++)
                {
                    for (int k = 2; k < Input.Length; k++)
                    {
                        var valueOne = int.Parse(Input[i]);
                        var valueTwo = int.Parse(Input[j]);
                        var valueThree = int.Parse(Input[k]);
                        if ((valueOne + valueTwo + valueThree) == 2020)
                        {
                            return valueOne * valueTwo * valueThree;
                        }
                    }
                }
            }
            return -1;
        }

    }
}
