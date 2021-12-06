using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day10
{
    public class ProgramDay10
    {
        public List<int> Adapters { get; set; } = new List<int>();
        public List<int> ValidAdapters { get; set; } = new List<int>();
        public List<List<int>> Groups { get; set; } = new List<List<int>>();

        public ProgramDay10(string path)
        {
            var temp = Array.ConvertAll(System.IO.File.ReadAllLines(path), x => int.Parse(x));
            Array.Sort(temp);
            Adapters.Add(0);
            Adapters.AddRange(temp);
            var lastAdapter = Adapters.Last() + 3;
            Adapters.Add(lastAdapter);
        }

        public void GetValidAdapters()
        {
            var currentJolt = 0;
            for (int i = 0; i < Adapters.Count; i++)
            {
                if (Adapters[i] - currentJolt <= 3)
                {
                    ValidAdapters.Add(Adapters[i]);
                    currentJolt = Adapters[i];
                } 
                else
                {
                    break;
                }
            }
        }

        public int ReturnJoltDifferences(int jolt)
        {
            var counter = 0;
            var currentJolt = 0;
            for (int i = 0; i < ValidAdapters.Count; i++)
            {
                if (ValidAdapters[i] - currentJolt == jolt)
                {
                    counter++;
                }
                currentJolt = ValidAdapters[i];
            }
            Console.WriteLine($"{jolt} Jolt = { counter }");
            return counter;
        }

        public void CreateGroups()
        {
            var previous = -1;
            var group = new List<int>();
            foreach (var adapter in ValidAdapters)
            {
                if (adapter != previous + 1)
                {
                    Groups.Add(group);
                    group = new List<int>();
                }
                group.Add(adapter);
                previous = adapter;
            }
        }

        public long ReturnPossibleArrangments()
        {
            var paths = 1L;
            foreach (var group in Groups)
            {
                switch (group.Count)
                {
                    case 3:
                        paths *= 2;
                        break;
                    case 4:
                        paths *= 4;
                        break;
                    case 5:
                        paths *= 7;
                        break;
                    default:
                        break;
                }
            }
            return paths;
        }

        public void SolutionRutger()
        {
            ulong[] cnts = new ulong[ValidAdapters.Count];
            cnts[0] = 1;
            for (int i = 0; i < ValidAdapters.Count; i++)
                for (int j = i + 1; j < Math.Min(ValidAdapters.Count, i + 4); j++)
                    if (ValidAdapters[j] <= ValidAdapters[i] + 3)
                        cnts[j] += cnts[i];
        }
    }
}
