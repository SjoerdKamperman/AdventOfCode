using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day3
{
    public class ProgramDay3
    {
        public string[] Input { get; set; }

        public ProgramDay3(string path)
        {
            Input = System.IO.File.ReadAllLines(path);
        }

        public long ExecuteProgramOne(int right, int down)
        {
            var grid = new Grid(Input, right);
            var visitedPoints = new List<Point>();
            var currentY = 0;
            for (int i = down; i < Input.Length; i+=down)
            {
                currentY += right;
                var visitedPoint = grid.Points.Where(x => x.X == i && x.Y == currentY).Single();
                visitedPoints.Add(visitedPoint);
            }

            long encounteredTrees = visitedPoints.Where(x => x.HasTree).ToList().Count;

            Console.WriteLine("How many trees would you encounter? " + encounteredTrees);
            return encounteredTrees;
        }

    }
}
