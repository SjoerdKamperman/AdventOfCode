using AdventOfCode.Shared.Intf;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class SolveDay08 : ISolve
    {
        public string[] Input { get; set; }
        private readonly HashSet<(int, int)> _visibleMap = new HashSet<(int, int)>();

        public SolveDay08()
        {
            Input = File.ReadAllLines("Inputs/Day08.txt");
        }

        public void SolvePartOne()
        {
            // horizontal views
            for (var y = 1; y < Input.Length - 1; y++)
            {
                MarkVisibles(y, 0, 0, 1);
                MarkVisibles(y, Input[0].Length - 1, 0, -1);
            }

            // vertical views    
            for (var x = 1; x < Input[0].Length - 1; x++)
            {
                MarkVisibles(0, x, 1, 0);
                MarkVisibles(Input.Length - 1, x, -1, 0);
            }

            Console.WriteLine(_visibleMap.Count + Input.Length * 2 + Input[0].Length * 2 - 4);
        }

        public void SolvePartTwo()
        {
            var maxScore = 0;

            for (var y = 1; y < Input.Length - 1; y++)
            {
                for (var x = 1; x < Input[0].Length - 1; x++)
                {
                    var top = CountTrees(y, x, -1, 0);
                    var bottom = CountTrees(y, x, 1, 0);
                    var left = CountTrees(y, x, 0, -1);
                    var right = CountTrees(y, x, 0, 1);
                    var score = top * bottom * left * right;
                    maxScore = Math.Max(maxScore, score);
                }
            }

            Console.WriteLine(maxScore);
        }

        public void MarkVisibles(int y, int x, int dy, int dx)
        {
            var treeHeight = Input[y][x];
            var ey = dy == 1 ? Input.Length - 1 : 0;
            var ex = dx == 1 ? Input[0].Length - 1 : 0;
            for (int x2 = x + dx, y2 = y + dy; x2 != ex && y2 != ey; x2 += dx, y2 += dy)
            {
                var height = Input[y2][x2];
                if (height > treeHeight)
                {
                    _visibleMap!.Add((y2, x2));
                    treeHeight = height;
                }
            }
        }

        public int CountTrees(int y, int x, int dy, int dx)
        {
            var height = Input[y][x];
            var trees = 0;
            var ey = dy == 1 ? Input.Length : -1;
            var ex = dx == 1 ? Input[0].Length : -1;
            for (int x2 = x + dx, y2 = y + dy; x2 != ex && y2 != ey; x2 += dx, y2 += dy)
            {
                trees++;
                if (height <= Input[y2][x2])
                {
                    break;
                }
            }
            return trees;
        }
    }
}