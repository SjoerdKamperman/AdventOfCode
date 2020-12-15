using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode2020.Day15
{
    public class ProgramDay15
    {
        public int[] Input { get; set; }
        public Dictionary<int, int[]> Memory { get; set; }

        public ProgramDay15(string path, int day)
        {
            var temp = System.IO.File.ReadAllText(string.Format(path, day)).Split(',');
            Input = Array.ConvertAll(temp, x => int.Parse(x));
        }

        public void SolveOne(int turns)
        {
            Console.WriteLine("Program started");
            var time = new Stopwatch();
            time.Start();
            Memory = new Dictionary<int, int[]>();
            var previous = ProcessInput();
            for (int i = Input.Length + 1; i <= turns; i++)
            {
                if (Memory.ContainsKey(previous))
                {
                    var spoken = Memory.GetValueOrDefault(previous);
                    if (spoken[0] == 1)
                    {
                        //Console.WriteLine($"Turn {i}: {previous} was first time spoken, so 0!");
                        previous = 0;
                        Memory[previous][0] = 2;
                    }
                    else
                    {
                        var difference = (i-1) - spoken[1];
                        Memory[previous][1] = i-1;
                        UpdateMemory(difference, i);
                        //Console.WriteLine($"Turn {i}: {previous} was multiple times spoken, so {difference}!");
                        previous = difference;
                    }
                }
            }
            time.Stop();
            Console.WriteLine($"Answer of Question One is {previous} and has taken {time.ElapsedMilliseconds}ms");
        }

        private int ProcessInput()
        {
            var result = 0;
            for (int j = 0; j < Input.Length; j++)
            {
                Memory.Add(Input[j], new int[2] { 1, j+1 });
                result =  Input[j];
            }
            return result;
        }

        private void UpdateMemory(int key, int position)
        {
            if (Memory.ContainsKey(key))
            {
                Memory[key][0] = 2;
            }
            else
            {
                Memory.Add(key, new int[2] { 1, position });

            }
        }
    }
}
