using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day18
{
    class Position
    {
        public Position(int x, int y, char valuePosition)
        {
            X = x;
            Y = y;
            ValuePosition = valuePosition;
        }

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public char ValuePosition { get; set; }
    }
}
