using AdventOfCode2020.Day1;
using AdventOfCode2020.Day2;
using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            // Day 1 Completed
            //var day1 = new ProgramDay1(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day1\day1.txt");
            //Console.WriteLine("Outcome of day 1 is: " + day1.ExecuteExpenseReportSumOfTwo());

            var day2_1 = new ProgramDay2(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day2\day2.txt");
            var day2_2 = new ProgramDay2(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day2\day2.txt");
            Console.WriteLine("Outcome of day 2-1 is: " + day2_1.ExecuteProgramOld());
            Console.WriteLine("Outcome of day 2-2 is: " + day2_2.ExecuteProgramNew());
        }
    }
}
