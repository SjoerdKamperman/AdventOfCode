using AdventOfCode.Shared.Intf;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class SolveDay09 : ISolve
    {
        public string[] Input { get; set; }
        private readonly HashSet<(int, int)> _visitedPoints  = new HashSet<(int, int)> ();
        private readonly List<(int x, int y)> _snake = new List<(int x, int y)>();

        public SolveDay09()
        {
            Input = File.ReadAllLines("Inputs/Day09.txt");
        }

        public void SolvePartOne()
        {
            _snake.Clear();
            _visitedPoints.Clear();
            for (var i = 0; i < 2; i++)
            {
                _snake.Add((0, 0));
            }

            ExecuteMoves();

            Console.WriteLine(_visitedPoints.Count);
        }

        public void SolvePartTwo()
        {
            _snake.Clear();
            _visitedPoints.Clear();
            for (var i = 0; i < 10; i++)
            {
                _snake.Add((0, 0));
            }

            ExecuteMoves();

            Console.WriteLine(_visitedPoints.Count);
        }

        private void ExecuteMoves()
        {
            foreach (var line in Input)
            {
                var command = line.Split(' ');
                var steps = int.Parse(command[1]);

                for (var step = 0; step < steps; step++)
                {
                    switch (command[0])
                    {
                        case "L":
                            Move(-1, 0);
                            break;
                        case "R":
                            Move(1, 0);
                            break;
                        case "U":
                            Move(0, 1);
                            break;
                        case "D":
                            Move(0, -1);
                            break;
                    }
                }
            }
        }

        private void Move(int dx, int dy)
        {
            _snake[0] = (_snake[0].x + dx, _snake[0].y + dy);
            for (var i = 1; i < _snake.Count; i++)
            {
                MoveTail(i);
            }
            _visitedPoints.Add(_snake.Last());
        }

        private void MoveTail(int part)
        {
            var head = _snake[part - 1];
            var tail = _snake[part];

            var dx = Difference(head.x - tail.x);
            var dy = Difference(head.y - tail.y);

            if (dx != 0 && head.y != tail.y)
                dy = Difference(head.y - tail.y, false);

            else if (dy != 0 && head.x != tail.x)
                dx = Difference(head.x - tail.x, false);

            _snake[part] = (tail.x + dx, tail.y + dy);
        }

        private int Difference(int difference, bool zero = true)
        {
            switch (difference)
            {
                case 2: return 1;
                case -2: return -1;
                default: return zero ? 0 : difference;
            }
        }
    }
}