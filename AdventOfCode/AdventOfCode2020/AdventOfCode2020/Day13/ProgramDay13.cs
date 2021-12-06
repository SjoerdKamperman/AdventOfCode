using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day13
{
    class ProgramDay13
    {
        public string[] Input { get; set; }
        public int TimeStampDepart { get; set; }
        public List<string> BusIds { get; set; } = new List<string>();
        public Dictionary<int, int> TimeDifferences { get; set; } = new Dictionary<int, int>();

        public ProgramDay13(string path)
        {
            Input = System.IO.File.ReadAllLines(path);
        }

        public void Solve()
        {
            ProcessInput();
            foreach (var busId in BusIds)
            {
                if (!busId.Contains("x"))
                {
                    var temp = int.Parse(busId);
                    var timeDifference = temp - (TimeStampDepart % temp);
                    TimeDifferences.Add(int.Parse(busId), timeDifference);
                }
            }
            var closestBusId = TimeDifferences.OrderBy(x => x.Value).First();
            var answer = closestBusId.Key * closestBusId.Value;
            Console.WriteLine($"Closed bus is {closestBusId.Key} with {closestBusId.Value} minutes. Answer is: {answer}");

            // Part 2
            {
                string[] busId = Input[1].Split(",");
                var time = 0L;
                var increaseTime = long.Parse(busId[0]);
                for (var i = 1; i < busId.Length; i++)
                {
                    if (!busId[i].Equals("x"))
                    {
                        var newTime = int.Parse(busId[i]);
                        while (true)
                        {
                            time += increaseTime;
                            if ((time + i) % newTime == 0)
                            {
                                increaseTime *= newTime;
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine("Second Answer is " + time);
            }

            //var timeDifferencesT = new Dictionary<string, int?>();
            //var counter = 1;
            //for (int i = 0; i < BusIds.Count; i++)
            //{
            //    if (!BusIds[i].Contains('x'))
            //    {
            //        timeDifferencesT.Add(BusIds[i], int.Parse(BusIds[i]));
            //    }
            //    else
            //    {
            //        timeDifferencesT.Add($"{BusIds[i]}", null);
            //    }
            //}
            //var perfectT = false;
            //while (!perfectT)
            //{
            //    string previous = timeDifferencesT.First().Key;
            //    foreach (var busId in BusIds)
            //    {
            //        if (!busId.Contains('x'))
            //        {
            //            timeDifferencesT[busId] += int.Parse(busId);
            //        } else
            //        {
            //            timeDifferencesT[busId] = timeDifferencesT[previous]+1;
            //        }
            //        previous = timeDifferencesT.Keys.Where(x => x.Equals(busId)).First();
            //    }

            //    previous = timeDifferencesT.First().Key;
            //    perfectT = true;
            //    foreach (var t in timeDifferencesT)
            //    {
            //        if (timeDifferencesT[previous] - t.Value > 1)
            //        {
            //            perfectT = false;
            //        }
            //        previous = t.Key;
            //    }
            //}
            //Console.WriteLine("Second answer = " + timeDifferencesT.First().Value);
        }




        private void ProcessInput()
        {
            TimeStampDepart = int.Parse(Input[0]);
            var temp = Input[1].Split(',');
            var id = 1;
            for (int i = 0; i < temp.Length; i++)
            {
                if (!temp[i].Equals("x"))
                {
                    BusIds.Add(temp[i]);
                }
                else
                {
                    BusIds.Add($"x-{id}");
                }
                id++;
            }
        }

    }
}
