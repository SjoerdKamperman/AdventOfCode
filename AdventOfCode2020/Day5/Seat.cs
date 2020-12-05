using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day5
{
    public class Seat
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int SeatId { get; set; }

        public Seat(int row, int column)
        {
            Row = row;
            Column = column;
            SeatId = (Row * 8) + Column;
        }
    }
}
