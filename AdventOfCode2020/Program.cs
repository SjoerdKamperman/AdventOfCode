using AdventOfCode2020.Day1;
using AdventOfCode2020.Day2;
using AdventOfCode2020.Day3;
using AdventOfCode2020.Day4;
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

            //Day 2 Completed
            //var day2_1 = new ProgramDay2(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day2\day2.txt");
            //var day2_2 = new ProgramDay2(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day2\day2.txt");
            //Console.WriteLine("Outcome of day 2-1 is: " + day2_1.ExecuteProgramOld());
            //Console.WriteLine("Outcome of day 2-2 is: " + day2_2.ExecuteProgramNew());

            //Day 3
            //var day3 = new ProgramDay3(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day3\day3.txt");
            //var option1 = day3.ExecuteProgramOne(1,1);
            //var option2 = day3.ExecuteProgramOne(3,1);
            //var option3 = day3.ExecuteProgramOne(5,1);
            //var option4 = day3.ExecuteProgramOne(7,1);
            //var option5 = day3.ExecuteProgramOne(1,2);
            //var result = option1 * option2 * option3 * option4 * option5;
            //Console.WriteLine("Outcome is: " + result);

            //Day 4
            var day4 = new ProgramDay4(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day4\day4.txt");
            day4.ConvertInputToPassportList();
            day4.ReturnValidPassports();
        }
    }
}
