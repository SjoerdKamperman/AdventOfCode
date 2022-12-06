using AdventOfCode.Shared.Intf;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace AdventOfCode2022
{
    public class SolveDay02 : ISolve
    {
        public string[] Input { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();


        public SolveDay02()
        {
            Input = File.ReadAllLines("Inputs/Day02.txt");
            foreach (var input in Input)
            {
                var plays = input.Split(' ');
                Games.Add(new Game(plays[0], plays[1]));
            }
        }

        public void SolvePartOne()
        {
            var totalScore = Games.Select(x => x.Points).ToList().Sum();
            Console.WriteLine(totalScore);
        }

        public void SolvePartTwo()
        {
            Console.WriteLine("SolveTwo");
        }
    }

    public class Game
    {
        public Item OpponentOutcome { get; set; }
        public Item YourOutcome { get; set; }
        public int Points { get; }

        public Game(string opponent, string yours)
        {
            OpponentOutcome = ConvertOpponent(opponent);
            YourOutcome = ConvertYours(yours);

            Points = DeterminePoints();
        }

        private int DeterminePoints()
        {
            var selectedShape = (int)YourOutcome;
            var outcome = DetermineOutcome();

            return selectedShape + outcome;
        }

        private int DetermineOutcome()
        {
            if (OpponentOutcome == YourOutcome)
                return 3;
            if ((OpponentOutcome == Item.Rock && YourOutcome == Item.Sciccors) ||
                (OpponentOutcome == Item.Sciccors && YourOutcome == Item.Paper) ||
                (OpponentOutcome == Item.Paper && YourOutcome == Item.Rock))
                return 0;
            return 6;
        }

        private Item ConvertYours(string yours)
        {
            return yours switch
            {
                "X" => DeterminePlay(OpponentOutcome,- 1),
                "Y" => DeterminePlay(OpponentOutcome, 0),
                "Z" => DeterminePlay(OpponentOutcome, 1),
                _ => throw new NotImplementedException(),
            };
        }

        private static Item DeterminePlay(Item playOpponent, int result)
        {
            if (result == 1)
            {
                return playOpponent switch
                {
                    Item.Rock => Item.Paper,
                    Item.Paper => Item.Sciccors,
                    Item.Sciccors => Item.Rock,
                    _ => throw new NotImplementedException(),
                };
            }

            if (result == 0)
            {
                return playOpponent;
            }

            return playOpponent switch
            {
                Item.Rock => Item.Sciccors,
                Item.Paper => Item.Rock,
                Item.Sciccors => Item.Paper,
                _ => throw new NotImplementedException(),
            };
        }

        private Item ConvertOpponent(string opponent)
        {
            return opponent switch
            {
                "A" => Item.Rock,
                "B" => Item.Paper,
                "C" => Item.Sciccors,
                _ => throw new NotImplementedException(),
            };
        }
    }

    public enum Item
    {
        Rock = 1,
        Paper = 2,
        Sciccors = 3
    }
}