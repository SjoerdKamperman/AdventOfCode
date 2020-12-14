using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day14
{
    public class ProgramDay14
    {
        public string[] Input { get; set; }
        public List<Initializer> InitProgram { get; set; }
        public Dictionary<int, List<long>> Memory { get; set; }
        public Dictionary<long, long> MemoryVersion2 { get; set; }
        public string CurrentMask { get; set; }
        public long Answer { get; set; } = 0;

        public ProgramDay14(string path, int day)
        {
            Input = System.IO.File.ReadAllLines(string.Format(path, day));
        }

        public void SolveOne()
        {
            ProcessInput();
            Memory = new Dictionary<int, List<long>>();
            MemoryVersion2 = new Dictionary<long, long>();
            foreach (var initializer in InitProgram)
            {
                if (initializer.Task.Equals("mask"))
                {
                    CurrentMask = initializer.Mask;
                }
                else
                {
                    var encodedValue = EncodeTo36Bit(long.Parse(initializer.Task));
                    Console.WriteLine($"value:  {encodedValue} (decimal {initializer.Value})");
                    Console.WriteLine($"mask:   {CurrentMask}");
                    var maskedAddress = ExecMask(encodedValue, false);
                    var listOfAddresses = ExecMask(maskedAddress[0], true);
                    var decodedValue = DecodeFrom36Bit(listOfAddresses);
                    Console.WriteLine($"result: {encodedValue} (decimal {decodedValue[0]})");
                    Console.WriteLine();

                    var key = int.Parse(initializer.Task);

                    foreach (var address in decodedValue)
                    {
                        if (MemoryVersion2.ContainsKey(address))
                        {
                            MemoryVersion2[address] = initializer.Value.Value;
                        }
                        else
                        {
                            MemoryVersion2.Add(address, initializer.Value.Value);
                        }
                    }
                    //if (Memory.ContainsKey(key))
                    //{
                    //    Answer -= Memory.GetValueOrDefault(key).Sum(x => x);
                    //    Answer += decodedValue.Sum(x => x);
                    //    Memory[key] = decodedValue;
                    //}
                    //else
                    //{
                    //    Memory.Add(key, decodedValue);
                    //    Answer += decodedValue.Sum(x => x);
                    //}
                }
            }
            Answer = MemoryVersion2.Values.Sum(x => x);
            Console.WriteLine($"First Answers is: " + Answer);
        }

        private List<string> ExecMask(string value, bool floating)
        {
            var ret = new List<string>();
            ret.Add("");
            var tempValue = new StringBuilder(value);
            for (int i = 0; i < CurrentMask.Length; i++)
            {
                if (floating)
                {
                    if (CurrentMask[i].Equals('X'))
                    {
                        int s = ret.Count;

                        for (int j = 0; j < s; j++)
                        {
                            var add = ret.ElementAt(0);
                            ret.RemoveAt(0);
                            ret.Add(add + "0");
                            ret.Add(add + "1");
                        }
                    }
                    else if (CurrentMask[i].Equals('1'))
                    {
                        for (int j = 0; j < ret.Count; j++)
                        {
                            ret[j] = ret[j] + "1";
                        }
                    }
                    else if (CurrentMask[i].Equals('0'))
                    {
                        for (int j = 0; j < ret.Count; j++)
                        {
                            ret[j] = ret[j] + value.Substring(i, 1);
                        }
                    }
                }
                else
                {
                    if (CurrentMask[i].Equals('X'))
                    {
                        tempValue.Remove(i, 1);
                        tempValue.Insert(i, "X");
                    }
                    else if (CurrentMask[i].Equals('1'))
                    {
                        tempValue.Remove(i, 1);
                        tempValue.Insert(i, "1");
                    }
                    else if (CurrentMask[i].Equals('0'))
                    {
                        tempValue.Remove(i, 1);
                        tempValue.Insert(i, value.Substring(i, 1));
                    }
                }
            }

            if (!floating)
            {
                ret.RemoveAt(0);
                ret.Add(tempValue.ToString());
            }
            
            return ret;

        }

        private string EncodeTo36Bit(long value)
        {
            var bit = Convert.ToString(value, 2);
            bit = bit.PadLeft(36, '0');
            return bit;
        }

        private List<long> DecodeFrom36Bit(List<string> values)
        {
            var ret = new List<long>();
            foreach (var value in values)
            {
                var longValue = Convert.ToInt64(value, 2);
                ret.Add(longValue);
            }
            return ret;
        }

        private void ProcessInput()
        {
            InitProgram = new List<Initializer>();
            foreach (var line in Input)
            {
                var init = line.Split(" = ");
                if (init[0].Equals("mask"))
                {
                    InitProgram.Add(new Initializer(init[0], init[1]));
                }
                else
                {
                    InitProgram.Add(new Initializer(Regex.Match(init[0], @"\d+").ToString(), int.Parse(init[1])));
                }
            }
        }
    }
}
