using AdventOfCode.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day_02 : BaseDay
    {
        public string[] Input { get; set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Z { get; set; } = 0;

        private const string FORWARD = "forward";
        private const string DOWN = "down";
        private const string UP = "up";

        public Day_02()
        {
            Input = System.IO.File.ReadAllLines(InputFilePath);
        }

        public new void Solve_One()
        {
            foreach (var input in Input)
            {
                ExecuteCommand(input);

            }
            Result = (X * Y).ToString();
            base.Solve_One();
        }

        public new void Solve_Two()
        {
            ClearResult();
            foreach (var input in Input)
            {
                ExecuteCommand(input);

            }
            Result = (X *Z).ToString();
            base.Solve_Two();
        }

        private void ClearResult()
        {
            X = 0;
            Y = 0;
        }

        private void ExecuteCommand(string input)
        {
            var extractedCommand = input.Split(' ');
            var positionIncrease = int.Parse(extractedCommand[1]);

            TakeAction(extractedCommand[0], positionIncrease);
            
        }

        private void TakeAction(string action, int positionIncrease)
        {
            switch (action)
            {
                case FORWARD:
                    X += positionIncrease;
                    Z += Y * positionIncrease;
                    break;
                case DOWN:
                    Y += positionIncrease;
                    break;
                case UP:
                    Y -= positionIncrease;
                    break;
            }
        }
    }
}
