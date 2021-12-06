using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day7
{
    public class ProgramDay7
    {
        public string[] Input { get; set; }
        public List<BagRegulation> BagRegulations { get; set; } = new List<BagRegulation>();

        public ProgramDay7(string path)
        {
            Input = System.IO.File.ReadAllLines(path);
        }

        public void ConvertInputIntoBagRegulations()
        {
            foreach (var line in Input)
            {
                var regulations = line.Split("contain");
                BagRegulations.Add(new BagRegulation(regulations[0], regulations[1]));
            }
        }

        public int FindTotalBagColorsNeeded(string coloredBag)
        {
            var bagColorsNeededDirectly = BagRegulations.FindAll(x => x.OtherBags.ContainsKey(coloredBag)).ToList();
            var totalNeeded = bagColorsNeededDirectly.Count;
            var counter = 0;
            while (counter < bagColorsNeededDirectly.Count)
            {
                var temp = BagRegulations.FindAll(x => x.OtherBags.Keys.Contains(bagColorsNeededDirectly[counter].FirstBag)).Except(bagColorsNeededDirectly).ToList();
                totalNeeded += temp.Count;
                bagColorsNeededDirectly.AddRange(temp);
                counter++;
            }
            return totalNeeded;
        }

        public int TotalBagsNeeded(string mainBag)
        {
            var bagColorsNeededDirectly = BagRegulations.FindAll(x => x.FirstBag.Equals(mainBag)).ToList();
            var counter = 0;
            while (counter < bagColorsNeededDirectly.Count)
            {
                foreach (var key in bagColorsNeededDirectly[counter].OtherBags)
                {
                    for (int i = 0; i < key.Value; i++)
                    {
                        var temp = BagRegulations.FindAll(x => x.FirstBag.Equals(key.Key)).ToList();
                        bagColorsNeededDirectly.AddRange(temp);
                    }
                }
                counter++;
            }
            var total = 0;
            bagColorsNeededDirectly.ForEach(x => total += x.OtherBags.Values.Sum());
            return total;
        }
    }
}
