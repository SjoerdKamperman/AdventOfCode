using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day16
{
    public class ProgramDay16
    {
        public string[] Input { get; set; }
        public List<int[]> Fields { get; set; }
        public List<int[]> NearbyTickets { get; set; }
        public int[] OwnTicket { get; set; }

        public ProgramDay16(string path, int day)
        {
            Input = System.IO.File.ReadAllLines(string.Format(path, day));
        }

        public void SolveOne()
        {
            var timer = new Stopwatch();
            timer.Start();
            var totalSum = 0;
            ProcessInput();
            foreach (var ticket in NearbyTickets)
            {
                foreach (var number in ticket)
                {
                    var valid = false;
                    foreach (var field in Fields)
                    {
                        if ((number >= field[0] && number <= field[1]) || (number >= field[2] && number <= field[3]))
                        {
                            valid = true;
                            break;
                        }
                    }
                    if (!valid)
                    {
                        totalSum += number;
                    }
                }
            }
            timer.Stop();
            Console.WriteLine($"Answer of question one is: {totalSum} - Duration: {timer.ElapsedMilliseconds}ms");
        }

        public void SolveTwo()
        {
			var input = Input.ToList();
			var rules = new Dictionary<string, Tuple<int, int, int, int>>();
			var ruleValid = new Dictionary<string, int[]>();
			var myTicket = new List<int>();
			var otherTickets = new List<List<int>>();
			var ticketBad = new List<List<int>>();
			string[] fields;
			int i;
			for (i = 0; i < input.Count; i++)
			{
				Match match = Regex.Match(input[i], @"([a-z ]+): (\d+)-(\d+) or (\d+)-(\d+)", RegexOptions.Compiled);
				if (match.Success)
				{
					rules[match.Groups[1].Value] = new Tuple<int, int, int, int>(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value));
				}
				//rules[]
				if (input[i] == "") break;
			}
			i += 2;
			foreach (var item in input[i].Split(','))
			{
				if (item != "" && int.TryParse(item, out int res)) myTicket.Add(res);
			}

			i += 2;
			for (; i < input.Count; i++)
			{
				var list = new List<int>();
				foreach (var item in input[i].Split(','))
				{
					if (item != "" && int.TryParse(item, out int res)) list.Add(res);
				}
				if (list.Count != 0) otherTickets.Add(list);
			}

			foreach (var rule in rules)
			{
				ruleValid[rule.Key] = new int[myTicket.Count];
			}

			List<int> badValues = new List<int>();
			foreach (var ticket in otherTickets)
			{
				for (int n = 0; n < ticket.Count; n++)
				{
					int num = ticket[n];
					bool noGood = true;
					foreach (var rule in rules)
					{
						if ((rule.Value.Item1 <= num && num <= rule.Value.Item2) || (rule.Value.Item3 <= num && num <= rule.Value.Item4))
						{
							noGood = false;
						}
					}
					if (noGood)
					{
						badValues.Add(num);
						ticketBad.Add(ticket);
					}
				}
			}
			Console.WriteLine(badValues.Sum(item => item));
			otherTickets.RemoveAll(ticket => ticketBad.Contains(ticket));
			badValues.Clear();
			foreach (var ticket in otherTickets)
			{
				for (int n = 0; n < ticket.Count; n++)
				{
					int num = ticket[n];
					bool noGood = true;
					foreach (var rule in rules)
					{
						if ((rule.Value.Item1 <= num && num <= rule.Value.Item2) || (rule.Value.Item3 <= num && num <= rule.Value.Item4))
						{
							ruleValid[rule.Key][n]++;
							noGood = false;
						}
					}
					if (noGood)
					{
						badValues.Add(num);
						ticketBad.Add(ticket);
					}
				}
			}
			fields = new string[myTicket.Count];
			//ruleValid.Where(item=>item.Value.)
			while (true)
			{
				var singleField = ruleValid.Where(item => item.Value.Count(ok => ok == otherTickets.Count) == 1);
				if (singleField.Count() == 0) break;
				foreach (var rule in singleField)
				{
					int index = Array.FindIndex(rule.Value, item => item == otherTickets.Count);
					fields[index] = rule.Key;
					foreach (var rule2 in ruleValid)
					{
						rule2.Value[index] = 0;
					}
				}
			}
			long departure = 1;
			for (i = 0; i < fields.Length; i++)
			{
				//Console.WriteLine($"{fields[i]}: {myTicket[i]}");
				if (fields[i].StartsWith("departure")) departure *= myTicket[i];
			}
			Console.WriteLine(departure);
		}

        private void ProcessInput()
        {
            Fields = new List<int[]>();
            NearbyTickets = new List<int[]>();
            var currentType = NoteType.Field;
            foreach (var line in Input)
            {
                if (line.Equals("your ticket:"))
                {
                    currentType = NoteType.YourTicket;
                    continue;
                }
                if (line.Equals("nearby tickets:"))
                {
                    currentType = NoteType.NearByTickets;
                    continue;
                }
                switch (currentType)
                {
                    case NoteType.Field:
                        if (!line.Equals(""))
                        {
                            var fields = new int[4];
                            var ranges = Regex.Matches(line, @"\d+");
                            for (int i = 0; i < ranges.Count; i++)
                            {
                                fields[i] = int.Parse(ranges[i].Value);
                            }
                            Fields.Add(fields);
                        }
                        break;
                    case NoteType.YourTicket:
                        if (!line.Equals(""))
                        {
                            OwnTicket = Array.ConvertAll(line.Split(','), x => int.Parse(x));
                        }
                        break;
                    case NoteType.NearByTickets:
                        if (!line.Equals(""))
                        {
                            var ticket = Array.ConvertAll(line.Split(','), x => int.Parse(x));
                            NearbyTickets.Add(ticket);
                        }
                        break;
                }

            }
        }
    }
}
