using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day8
{
    public class ProgramDay8
    {
        public string[] Input { get; set; }

        public ProgramDay8(string path)
        {
            Input = System.IO.File.ReadAllLines(path);
        }

        public void ExecuteProgramOne()
        {
            var bootCode = new BootCode();
            bootCode.InsertInstructions(Input);
            bootCode.RunBootCode();            
        }
    }
}
