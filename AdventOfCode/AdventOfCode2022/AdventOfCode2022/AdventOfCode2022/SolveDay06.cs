using AdventOfCode.Shared.Intf;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class SolveDay06 : ISolve
    {
        public string[] Input { get; set; }

        public SolveDay06()
        {
            Input = File.ReadAllLines("Inputs/Day06.txt");
        }

        public void SolvePartOne()
        {
            var result = CalculateMarker(4);

            Console.WriteLine(result + 1);
        }

        private int CalculateMarker(int length)
        {
            var input = Input[0];
            var marker = input[0].ToString();

            for (int i = 1; i < input.Length; i++)
            {
                if (!marker.Contains(input[i]))
                {
                    marker += input[i];
                    if (marker.Length >= length)
                        return i;
                }
                else {
                    var index = marker.IndexOf(input[i]);
                    marker = marker.Substring(index + 1);
                    marker += input[i];
                }
            }

            return -1;
        }

        public void SolvePartTwo()
        {
            var result = CalculateMarker(14);

            Console.WriteLine(result + 1);
        }
    }
}