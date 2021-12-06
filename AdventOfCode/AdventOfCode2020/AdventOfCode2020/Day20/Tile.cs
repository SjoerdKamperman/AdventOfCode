using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day20
{
    public class Tile
    {
        public int TileId { get; set; }
        public string LeftEdge { get; set; }
        public string RightEdge { get; set; }
        public string TopEdge { get; set; }
        public string BottomEdge { get; set; }

        public Tile()
        {

        }
    }
}
