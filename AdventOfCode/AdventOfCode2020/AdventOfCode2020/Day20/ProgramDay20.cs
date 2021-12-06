using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode2020.Day20
{
    public class ProgramDay20 : AOCPuzzle
    {
        public List<Tile> Tiles { get; set; }

        public ProgramDay20(string path, int day) : base(path, day)
        {
        }

        public override void SolveOne()
        {
            var timer = new Stopwatch();
            timer.Start();
            ProcessInput();
            var answer = 1L;
            for (int i = 0; i < Tiles.Count; i++)
            {
                var top = false;
                var bottom = false;
                var left = false;
                var right = false;
                var td1 = Tiles[i];
                for (int j = 0; j < Tiles.Count; j++)
                {
                    if (i == j)
                        continue;

                    var td2 = Tiles[j];

                    if (Matches(td1.TopEdge, td2.BottomEdge) || Matches(td1.TopEdge, td2.TopEdge) || Matches(td1.TopEdge, td2.LeftEdge) || Matches(td1.TopEdge, td2.RightEdge))
                    {
                        top = true;
                    }
                    if (Matches(td1.BottomEdge, td2.BottomEdge) || Matches(td1.BottomEdge, td2.TopEdge) || Matches(td1.BottomEdge, td2.LeftEdge) || Matches(td1.BottomEdge, td2.RightEdge))
                    {
                        bottom = true;
                    }
                    if (Matches(td1.LeftEdge, td2.BottomEdge) || Matches(td1.LeftEdge, td2.TopEdge) || Matches(td1.LeftEdge, td2.LeftEdge) || Matches(td1.LeftEdge, td2.RightEdge))
                    {
                        left = true;
                    }
                    if (Matches(td1.RightEdge, td2.BottomEdge) || Matches(td1.RightEdge, td2.TopEdge) || Matches(td1.RightEdge, td2.LeftEdge) || Matches(td1.RightEdge, td2.RightEdge))
                    {
                        right = true;
                    }
                }
                int count = (top ? 0 : 1) + (bottom ? 0 : 1) + (left ? 0 : 1) + (right ? 0 : 1);
                if (count == 2)
                {
                    Console.WriteLine($"TileId Corner: {td1.TileId}");
                    answer *= td1.TileId;
                }
            }
            timer.Stop();
            Console.WriteLine($"Answer of questione one is {answer} - Duration: {timer.ElapsedMilliseconds}ms");

        }

        public override void SolveTwo()
        {
            throw new NotImplementedException();
        }

        private bool Matches(string t1, string t2)
        {
            return t1.Equals(t2) || t1.Equals(Reverse(t2));
        }

        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void ProcessInput()
        {
            Tiles = new List<Tile>();
            Tile tile = null;
            var last = "";
            foreach (var line in Input)
            {
                if (line.Contains("Tile"))
                {
                    tile = new Tile();
                    var temp = line.Trim(':').Replace("Tile ", "");
                    tile.TileId = int.Parse(temp);
                }
                else if (line.Equals(""))
                {
                    tile.BottomEdge = last;
                    last = "";
                    Tiles.Add(tile);
                }
                else
                {
                    if (string.IsNullOrEmpty(last))
                    {
                        tile.TopEdge = line;
                    }
                    last = line;
                    tile.LeftEdge += line.Substring(0, 1);
                    tile.RightEdge += line.Substring(line.Length - 1);
                }
            }
            tile.BottomEdge = last;
            Tiles.Add(tile);
        }
    }
}
