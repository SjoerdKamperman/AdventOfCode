using AdventOfCode2020.Day1;
using AdventOfCode2020.Day10;
using AdventOfCode2020.Day11;
using AdventOfCode2020.Day12;
using AdventOfCode2020.Day13;
using AdventOfCode2020.Day14;
using AdventOfCode2020.Day15;
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
            var path = @"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day{0}\day{0}.txt";
            // Day 1 Completed
            //var day1 = new ProgramDay1(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day01\day1.txt");
            //Console.WriteLine("Outcome of day 1 is: " + day1.ExecuteExpenseReportSumOfTwo());

            //Day 2 Completed
            //var day2_1 = new ProgramDay2(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day02\day2.txt");
            //var day2_2 = new ProgramDay2(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day02\day2.txt");
            //Console.WriteLine("Outcome of day 2-1 is: " + day2_1.ExecuteProgramOld());
            //Console.WriteLine("Outcome of day 2-2 is: " + day2_2.ExecuteProgramNew());

            //Day 3
            //var day3 = new ProgramDay3(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day03\day3.txt");
            //var option1 = day3.ExecuteProgramOne(1,1);
            //var option2 = day3.ExecuteProgramOne(3,1);
            //var option3 = day3.ExecuteProgramOne(5,1);
            //var option4 = day3.ExecuteProgramOne(7,1);
            //var option5 = day3.ExecuteProgramOne(1,2);
            //var result = option1 * option2 * option3 * option4 * option5;
            //Console.WriteLine("Outcome is: " + result);

            //Day 4
            //var day4 = new ProgramDay4(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day04\day4.txt");
            //day4.ConvertInputToPassportList();
            //day4.ReturnValidPassports();

            //Day 5
            //var day5 = new ProgramDay5(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day05\day5.txt");
            //day5.ExecuteProgram();

            //Day 6
            //var day6 = new ProgramDay6(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day06\day6.txt");
            //day6.ConvertInputToGroupAnswers();
            //day6.SumUpAnsweredYes();

            //Day 7
            //var day7 = new ProgramDay7(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day07\day7.txt");
            //day7.ConvertInputIntoBagRegulations();
            //var answer = day7.FindTotalBagColorsNeeded("shiny gold bags");
            //Console.WriteLine(answer);
            //answer = day7.TotalBagsNeeded("shiny gold bags");
            //Console.WriteLine(answer);

            //Day 8
            //var day8 = new ProgramDay8(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day08\day8.txt");
            //day8.ExecuteProgramOne();

            //Day 9
            //var day9 = new ProgramDay9(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day09\day9.txt", 25);
            //day9.ExecuteProgramOne();

            //Day 10
            //var day10 = new ProgramDay10(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day10\day10.txt");
            //day10.GetValidAdapters();
            //var jolt1 = day10.ReturnJoltDifferences(1);
            //var jolt3 = day10.ReturnJoltDifferences(3);
            //Console.WriteLine($"Answer of question is: { jolt1 * jolt3 }");
            //day10.CreateGroups();
            //var answer = day10.ReturnPossibleArrangments();
            //Console.WriteLine($"Answer of second question is: {answer} ");
            //day10.SolutionRutger();

            //Day 11
            // part 1
            //var day11 = new ProgramDay11(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day11\day11.txt");
            //day11.ProcessInput();
            //Console.WriteLine(day11.FindOccupiedAfterStabilized(4, false));

            // part 2
            //var day11 = new ProgramDay11(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day11\day11.txt");
            //day11.ProcessInput();
            //Console.WriteLine(day11.FindOccupiedAfterStabilized(5, true));

            //Day 12
            //var day12 = new ProgramDay12(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day12\day12.txt");
            //day12.Solve();

            //Day 13
            //var day13 = new ProgramDay13(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020\Day13\day13.txt");
            //day13.Solve();

            //Day 14
            //var day14 = new ProgramDay14(path, 14);
            //day14.SolveOne();

            //Day 15
            var day15 = new ProgramDay15(path, 15);
            day15.SolveOne(30000000);
        }
    }
}
