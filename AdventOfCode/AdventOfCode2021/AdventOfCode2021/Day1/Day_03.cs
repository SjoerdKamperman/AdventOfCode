using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public class Day_03 : BaseDay
    {
        public string[] Input { get; set; }
        public StringBuilder EpsilonRate { get; set; } = new StringBuilder();
        public StringBuilder GammaRate { get; set; } = new StringBuilder();

        public Day_03()
        {
            Input = System.IO.File.ReadAllLines(InputFilePath);
        }

        public new void Solve_One()
        {
            for (int i = 0; i < Input[0].Length; i++)
            {
                var counterOneBit = 0;
                var counterZeroBit = 0;
                foreach (var input in Input)
                {
                    if (input[i] == '1')
                        counterOneBit++;
                    else
                        counterZeroBit++;
                }
                EpsilonRate.Append(counterOneBit > counterZeroBit ? "0" : "1");
                GammaRate.Append(counterOneBit > counterZeroBit ? "1" : "0");
            }

            var epsilonInt = Convert.ToInt32(EpsilonRate.ToString(), 2);
            var gammaInt = Convert.ToInt32(GammaRate.ToString(), 2);

            Result = (epsilonInt * gammaInt).ToString();

            base.Solve_One();
        }

        public new void Solve_Two()
        {
            Result = (CalculateOxygen(Input) * CalculateCO2(Input)).ToString();
            base.Solve_Two();
        }

        private double CalculateOxygen(string[] input)
        {
            var oxygenInput = input.ToList();

            int[] oxygen = new int[oxygenInput[1].Length];

            // OXYGEN
            for (int i = 0; i < oxygen.Length; i++)
            {
                var columnList = oxygenInput.Select(x => int.Parse(x[i].ToString())).ToList();
                oxygen[i] = columnList.Where(x => x == 1).Count() >= columnList.Where(x => x == 0).Count() ? 1 : 0;
                oxygenInput.RemoveAll(x => x[i].ToString() != oxygen[i].ToString());
            }

            return ConvertToDecimal(oxygenInput[0]);
        }

        private double CalculateCO2(string[] input)
        {
            var co2Input = input.ToList();
            int[] coTwo = new int[co2Input[1].Length];
            int i = 0;
            // CO2
            while (co2Input.Count() > 1)
            {
                var columnList = co2Input.Select(x => int.Parse(x[i].ToString())).ToList();
                int ones = columnList.Where(x => x == 1).Count();
                int zeros = columnList.Where(x => x == 0).Count();

                if (ones < zeros)
                {
                    coTwo[i] = 1;
                }
                else
                {
                    coTwo[i] = 0;
                }
                co2Input.RemoveAll(x => x[i].ToString() != coTwo[i].ToString());
                i++;
            }

            return ConvertToDecimal(co2Input[0]);
        }

        private double ConvertToDecimal(string bin)
        {
            var reversedBinary = bin.Reverse().ToArray();
            double amt = 0;

            for (int i = 0; i < reversedBinary.Count(); i++)
            {
                amt += reversedBinary[i].ToString() == "1" ? Math.Pow(2, i) : 0;
            }

            return amt;
        }

        private void ClearResult()
        {

        }
    }
}
