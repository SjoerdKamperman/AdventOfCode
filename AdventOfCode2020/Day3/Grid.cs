using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day3
{
    class Grid
    {
        public List<Point> Points { get; set; } = new List<Point>();
        public int Right { get; set; }

        public Grid(string[] input, int right)
        {
            Right = right;
            var rows = input.Length;
            var lengthNeeded = rows * right;
            var rowLength = input[0].Length;
            var gridMultiplier = Math.Ceiling((double)lengthNeeded / rowLength);

            for (int i = 0; i < rows; i++)
            {
                var currentY = 0;
                var counter = 0;
                while (counter < gridMultiplier)
                {
                    for(int j = 0; j < rowLength; j++)
                    {
                        bool hasTree = input[i][j].Equals('#');
                        Points.Add(new Point(i, currentY, hasTree));
                        currentY++;
                    }
                    counter++;
                }
            }
        }

    }
}
