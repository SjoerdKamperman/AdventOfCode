using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day7
{
    public class BagRegulation
    {
        public string FirstBag { get; set; }
        public Dictionary<string, int> OtherBags { get; set; } = new Dictionary<string, int>();

        public BagRegulation(string firstBag, string input)
        {
            FirstBag = firstBag.Trim();
            var otherRegulations = input.Split(",");

            foreach (var regulation in otherRegulations)
            {
                var temp = Regex.Replace(regulation, @"\bbag\b", "bags");
                temp = temp.Replace(".", "").Trim();
                var regulationText = Regex.Match(temp, @"\D+").ToString().Trim();
                var regulationInt = 0;
                int.TryParse(Regex.Match(temp, @"\d").ToString().Trim(), out regulationInt);
                OtherBags.Add(regulationText, regulationInt);
            }
        }
    }
}
