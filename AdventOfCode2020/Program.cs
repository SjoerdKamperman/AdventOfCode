using AdventOfCode2020.Day1;
using AdventOfCode2020.Day2;
using AdventOfCode2020.Day3;
using AdventOfCode2020.Day4;
using AdventOfCode2020.Day5;
using AdventOfCode2020.Day6;
using AdventOfCode2020.Day7;
using AdventOfCode2020.Day8;
using AdventOfCode2020.Day9;
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
            //var day4 = new ProgramDay4(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day4\day4.txt");
            //day4.ConvertInputToPassportList();
            //day4.ReturnValidPassports();

            //Day 5
            //var day5 = new ProgramDay5(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day5\day5.txt");
            //day5.ExecuteProgram();

            //Day 6
            //var day6 = new ProgramDay6(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day6\day6.txt");
            //day6.ConvertInputToGroupAnswers();
            //day6.SumUpAnsweredYes();

            //Day 7
            //var day7 = new ProgramDay7(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day7\day7.txt");
            //day7.ConvertInputIntoBagRegulations();
            //var answer = day7.FindTotalBagColorsNeeded("shiny gold bags");
            //Console.WriteLine(answer);
            //answer = day7.TotalBagsNeeded("shiny gold bags");
            //Console.WriteLine(answer);

            //Day 8
            //var day8 = new ProgramDay8(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day8\day8.txt");
            //day8.ExecuteProgramOne();

            //Day 9
            var day9 = new ProgramDay9(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day9\day9.txt", 25);
            day9.ExecuteProgramOne();
        }
    }
}
