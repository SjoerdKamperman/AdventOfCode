using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day3
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasTree { get; set; }

        public Point(int x, int y, bool hasTree)
        {
            X = x;
            Y = y;
            HasTree = hasTree;
        }
    }
}
