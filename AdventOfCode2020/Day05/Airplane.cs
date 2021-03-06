﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day5
{
    public class Airplane
    {
        public List<Seat> Seats { get; set; } = new List<Seat>();

        public void FillSeats(string[] input)
        {
            foreach (var line in input)
            {
                var rowLine = line.Substring(0, 7);
                var columnLine = line.Substring(7);

                Console.WriteLine("Start search row (F/B)");
                var finalRow = BinarySearchBoardingPass(rowLine);
                Console.WriteLine($"Row found = {finalRow}");

                Console.WriteLine("Start search column (R/L)");
                var finalColumn = BinarySearchBoardingPass(columnLine);
                Console.WriteLine($"Column found = {finalColumn}");

                Seats.Add(new Seat(finalRow, finalColumn)); 
            }
        }

        public int GetHighestSeatNumber()
        {
            Seats = Seats.OrderBy(x => x.SeatId).ToList();
            foreach (var seat in Seats)
            {
                Console.WriteLine("Seat NR: " + seat.SeatId);
            }
            return Seats.Last().SeatId;
        }

        public int FindEmptySeat()
        {
            var list = new List<int>();
            foreach (var seat in Seats)
            {
                list.Add(seat.SeatId);
            }
            var emptySeat = Enumerable.Range(list.First(), list.Count).Except(list);
            return emptySeat.First();
        }

        private int BinarySearchBoardingPass(string input)
        {
            var binaryString = Regex.Replace(input, @"[B|R]", "1");
            var binaryStringCompleted = Regex.Replace(binaryString, @"[F|L]", "0");

            return Convert.ToInt32(binaryStringCompleted, 2);
            //double start = 0.0;
            //double end = posibilities;
            //foreach (var character in input)
            //{
            //    Console.WriteLine($"Current character = {character}");
            //    bool upperHalf = character.Equals('B') || character.Equals('R');
            //    if (upperHalf)
            //    {
            //        var temp = Math.Ceiling((end + start) / 2);
            //        start = temp;
            //    }
            //    else
            //    {
            //        var temp = Math.Floor((end + start) / 2);
            //        end = temp;
            //    }
            //}

            //return (int)start;
        }

    }
}
