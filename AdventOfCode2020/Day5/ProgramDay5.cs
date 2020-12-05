using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day5
{
    public class ProgramDay5
    {
        public string[] Input { get; set; }

        public ProgramDay5(string path)
        {
            Input = System.IO.File.ReadAllLines(path);
        }

        public void ExecuteProgram()
        {
            var airplane = new Airplane();

            airplane.FillSeats(Input);
            Console.WriteLine("Outcome is: " + airplane.GetHighestSeatNumber());
            Console.WriteLine("Empty seat is: " + airplane.FindEmptySeat());
        }
    }
}
