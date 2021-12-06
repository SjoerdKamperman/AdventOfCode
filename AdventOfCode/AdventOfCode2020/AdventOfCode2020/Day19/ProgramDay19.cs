using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day19
{
    public class ProgramDay19 : AOCPuzzle
    {
        public Dictionary<int, List<List<int>>> Rules { get; set; }
        public Dictionary<int, char> RulesEnd { get; set; }
        public List<string> Messages { get; set; }

        public ProgramDay19(string path, int day) : base(path, day)
        {
        }

        public override void SolveOne()
        {
            var timer = new Stopwatch();
            timer.Start();
            Rules = new Dictionary<int, List<List<int>>>();
            RulesEnd = new Dictionary<int, char>();
            Messages = new List<string>();
            var matches = 0;
            ProcessInput(Rules, RulesEnd, Messages);
            
            foreach (var c in Messages)
            {
                var chars = new List<char>();
                chars.AddRange(c.ToCharArray());
                if (Matches(chars, 0) && chars.Count == 0)
                {
                    matches++;
                }
            }
                
           

            timer.Stop();
            Console.WriteLine($"Anser of question one is: {matches}  - Duration: {timer.ElapsedMilliseconds}ms");
        }

        public override void SolveTwo()
        {
            throw new NotImplementedException();
        }

        private bool Matches(List<char> chars, int ruleNumber)
        {
            if (chars.Count == 0)
                return false;

            if (RulesEnd.ContainsKey(ruleNumber))
            {
                if (RulesEnd.GetValueOrDefault(ruleNumber).Equals(chars.ElementAt(0)))
                {
                    chars.RemoveAt(0);
                    return true;
                }
            }
            else
            {
                var rules = Rules.GetValueOrDefault(ruleNumber);
                foreach (var rule in rules)
                {
                    var matches = true;
                    var charsCopy = new List<char>(chars);
                    foreach (var i in rule)
                    {
                        if(!Matches(charsCopy, i))
                        {
                            matches = false;
                            break;
                        }
                    }
                    if (matches)
                    {
                        while (chars.Count > charsCopy.Count)
                        {
                            chars.RemoveAt(0);
                        }
                        return true;
                    }
                }                
            }
            return false;
        }
        
        private void ProcessInput(Dictionary<int, List<List<int>>> rules, Dictionary<int, char> rulesEnd, List<string> messages)
        {
            var rulesInput = true;
            foreach (var line in Input)
            {                
                if (rulesInput)
                {
                    if (line.Equals(""))
                    {
                        rulesInput = false;
                        continue;
                    }
                    var parts = line.Split(": ");
                    var ruleNumber = int.Parse(parts[0]);
                    if (parts[1].Contains("\""))
                    {
                        rulesEnd.Add(ruleNumber, parts[1].ElementAt(1));
                    }
                    else
                    {
                        var splittedRules = parts[1].Split("|");
                        var tempRules = new List<List<int>>();
                        foreach (var allRules in splittedRules)
                        {
                            var temp = allRules.Trim();
                            var rule = temp.Split(" ");
                            var tempRule = new List<int>();
                            foreach (var r in rule)
                            {
                                tempRule.Add(int.Parse(r));
                            }
                            tempRules.Add(tempRule);
                        }
                        rules.Add(ruleNumber, tempRules);
                    }
                   
                }
                else
                {
                    messages.Add(line);
                }
            }
        }
    }
}
