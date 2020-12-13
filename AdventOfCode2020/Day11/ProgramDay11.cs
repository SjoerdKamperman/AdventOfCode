using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day11
{
    public class ProgramDay11
    {
        public string[] Input { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MaxDim { get; set; }
		public Dictionary<Point, bool> Seats { get; set; } = new Dictionary<Point, bool>();
		public Dictionary<Point, List<Point>> NeighboursOf { get; set; } = new Dictionary<Point, List<Point>>();
        public bool Stable { get; set; }
        public Dictionary<Point, int> OccupiedNeighboursOf { get; set; }


        public ProgramDay11(string path)
        {
            Input = System.IO.File.ReadAllLines(path);
        }

        public void Solve()
        {
			ProcessInput();
		}

		public void ProcessInput()
		{
			Width = Input[0].Length;
			Height = Input.Length;
			MaxDim = Math.Max(Width, Height);
			OccupiedNeighboursOf = new Dictionary<Point, int>();
			int y = 0;
			foreach (var line in Input)
			{
				int x = 0;
				foreach (var character in line)
				{
					if (character.Equals('L'))
					{
						Seats.Add(new Point(x, y), false);
					}
					else if (character.Equals('#'))
					{
						Seats.Add(new Point(x, y), false);
					}
					x++;
				}
				y++;
			}
		}

		public int FindOccupiedAfterStabilized(int limit, bool useLineOfSight)
		{
			int occupied;
			if (useLineOfSight)
			{
				CalculateNeighboursLOS();
			}
			else
			{
				CalculateNeighbours();
			}
			do
			{
                PrintSeats();
                Stable = true;
				occupied = 0;
				Dictionary<Point, int> occupiedNew = new Dictionary<Point, int>();
				Dictionary<Point, bool> seatsNew = new Dictionary<Point, bool>();
				foreach (var p in Seats.Keys)
				{
					int occNeigh = OccupiedNeighboursOf.GetValueOrDefault(p);
					if (!Seats.GetValueOrDefault(p) && occNeigh == 0)
					{ // flip to occupied
						seatsNew.Add(p, true);
						Stable = false;
					}
					else if (Seats.GetValueOrDefault(p) && occNeigh >= limit)
					{ // flip to empty
						seatsNew.Add(p, false);
						Stable = false;
					}
					else
					{
						seatsNew.Add(p, Seats.GetValueOrDefault(p));
					}
					if (seatsNew.GetValueOrDefault(p))
					{
						occupied++;
						UpdateNeighbours(p, occupiedNew);
					}
				}
				Seats = seatsNew;
				OccupiedNeighboursOf = occupiedNew;
			} while (!Stable);
			return occupied;
		}

		private void CalculateNeighboursLOS()
		{
			foreach (var p in Seats.Keys)
			{
				NeighboursOf.Add(p, new List<Point>());
				for (int dx = -1; dx < 2; dx++)
				{
					for (int dy = -1; dy < 2; dy++)
					{
						if (dx != 0 || dy != 0)
						{
							for (int i = 1; i < MaxDim; i++)
							{
								int newX = p.X + i * dx;
								int newY = p.Y + i * dy;
								Point pn = new Point(newX, newY);
								if (newX >= 0 && newX < Width && newY >= 0 && newY < Height && Seats.ContainsKey(pn))
								{
									List<Point> nb = NeighboursOf.GetValueOrDefault(p);
									nb.Add(pn);
									NeighboursOf[p] = nb;
									break;
								}
							}
						}
					}
				}
			}
		}

		private void CalculateNeighbours()
		{
			foreach (var p in Seats.Keys)
			{
				NeighboursOf.Add(p, new List<Point>());
				for (int i = -1; i < 2; i++)
				{
					for (int j = -1; j < 2; j++)
					{
						Point pn = new Point(p.X + i, p.Y + j);
						if ((i != 0 || j != 0) && p.X + i >= 0 && p.X + i < Width && p.Y + j >= 0 && p.Y + j < Height && Seats.ContainsKey(p))
						{
							List<Point> nb = NeighboursOf.GetValueOrDefault(p);
							nb.Add(pn);
							NeighboursOf[p] = nb;
						}
					}
				}
			}
		}

		public void UpdateNeighbours(Point p, Dictionary<Point, int> occupiedNew)
		{
			foreach (var pn in NeighboursOf.GetValueOrDefault(p))
			{
				if (occupiedNew.ContainsKey(pn))
                {
					//var count = occupiedNew[pn] + 1;
					occupiedNew[pn] = occupiedNew.GetValueOrDefault(pn, 0) + 1;
				}
				else
                {
					occupiedNew.Add(pn, 1);
                }
			}
		}

		private void PrintSeats()
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					Point p = new Point(x, y);
					Console.Write(!Seats.ContainsKey(p) ? "." : Seats.GetValueOrDefault(p) ? "#" : "L");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}
