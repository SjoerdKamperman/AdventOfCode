using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Shared
{
    public abstract class BaseDay : BaseProblem
    {
        protected override string ClassPrefix { get; } = "Day";
        public string Result { get; set; }
        
        public void Solve_One()
        {
            Console.WriteLine(Result);
        }

        public void Solve_Two()
        {
            Console.WriteLine(Result);
        }
    }
}
