using AdventOfCode.Shared.Intf;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    public class SolveDay05 : ISolve
    {
        public string[] Input { get; set; }
        public Dictionary<int, Stack<string>> Stacks = new Dictionary<int, Stack<string>>();
        public List<string> Procedures = new List<string>();

        public SolveDay05()
        {
            Input = File.ReadAllLines("Inputs/Day05.txt");
            Prepare();

            var start = false;
            foreach (var line in Input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    start = true;
                    continue;
                }

                if (!start)
                    continue;

                Procedures.Add(line);
            }
        }

        private void Prepare()
        {
            Stacks = new Dictionary<int, Stack<string>>();
            var firstPart = Input.TakeWhile(x => !string.IsNullOrEmpty(x))
                            .Reverse()
                            .ToList();

            var firstLineProcessed = false;
            foreach (var line in firstPart)
            {
                var index = 0;
                var strings = new List<string>();

                while (index < line.Length)
                {
                    strings.Add(line.Substring(index, Math.Min(4, line.Length - index)));
                    index += 4;
                }

                if (!firstLineProcessed)
                {
                    strings.ForEach(x =>
                    {
                        Stacks.Add(int.Parse(x), new Stack<string>());
                    });
                    firstLineProcessed = true;
                    continue;
                }

                for (var i = 0; i < strings.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(strings[i]))
                    {
                        var regex = @"\[|\]";
                        var item = Regex.Replace(strings[i], regex, "");
                        Stacks[i + 1].Push(item.Trim());
                    }
                }
            }
        }

        public void SolvePartOne()
        {
            var result = "";

            foreach (var step in Procedures)
            {
                var steps = Regex.Matches(step, @"\d+").Cast<Match>().Select(x => int.Parse(x.Value)).ToList();
                var moves = steps[0];
                var from = steps[1];
                var to = steps[2];

                for (int i = 0; i < moves; i++)
                {
                    var item = Stacks[from].Pop();
                    Stacks[to].Push(item);
                }
            }

            foreach (var stack in Stacks)
            {
                var item = stack.Value.Peek();
                result += item;
            }

            Console.WriteLine(result);
        }

        public void SolvePartTwo()
        {
            Prepare();
            var result = "";

            foreach (var step in Procedures)
            {
                var steps = Regex.Matches(step, @"\d+").Cast<Match>().Select(x => int.Parse(x.Value)).ToList();
                var moves = steps[0];
                var from = steps[1];
                var to = steps[2];

                var tempStack = new Stack<string>();
                for (int i = 0; i < moves; i++)
                {
                    var item = Stacks[from].Pop();
                    tempStack.Push(item);
                }

                foreach (var stack in tempStack)
                {
                    Stacks[to].Push(stack);
                }
            }

            foreach (var stack in Stacks)
            {
                var item = stack.Value.Peek();
                result += item;
            }

            Console.WriteLine(result);
        }
    }
}