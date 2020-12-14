using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day14
{
    public class Initializer
    {
        public Initializer(string task, string mask)
        {
            Task = task;
            Mask = mask;
        }

        public Initializer(string task, long? value)
        {
            Task = task;
            Value = value;
        }

        public string Task { get; set; }
        public string Mask { get; set; }
        public long? Value { get; set; }
    }
}
