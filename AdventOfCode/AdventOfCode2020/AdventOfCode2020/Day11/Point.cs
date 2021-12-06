using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day11
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Point)) return false;
            return ((Point)obj).X == this.X && ((Point)obj).Y == this.Y;
        }

        public override int GetHashCode()
        {
            return (this.X + this.Y).GetHashCode();
        }
    }
}
