using AdventOfCode.Shared.Intf;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class SolveDay01 : ISolve
    {
        public string[] Input { get; set; }
        public List<List<int>> ElvesCalories { get; set; } = new List<List<int>>();

        public SolveDay01()
        {
            Input = File.ReadAllLines("Inputs/Day01.txt");
        }

        public void SolvePartOne()
        {
            var calories = new List<int>();
            var maxCalories = 0;
            foreach (var input in Input)
            {
                if (string.IsNullOrEmpty(input))
                {
                    var totalCalories = calories.Sum();
                    if (totalCalories > maxCalories)
                        maxCalories = totalCalories;

                    ElvesCalories.Add(calories);
                    calories = new List<int>();
                    continue;
                }

                calories.Add(int.Parse(input));
            }

            var orderedList = ElvesCalories.OrderByDescending(x => x.Sum());
            Console.WriteLine(orderedList.First().Sum());
        }

        public void SolvePartTwo()
        {
            var orderedList = ElvesCalories.OrderByDescending(x => x.Sum());
            var sum = 0;
            foreach (var item in orderedList.Take(3))
            {
                sum += item.Sum();
            }
            Console.WriteLine(sum);
        }
    }
}