using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day8
{
    class BootCode
    {
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
        public int Accumulator { get; set; } = 0;
        public int Position { get; set; } = 0;
        public Instruction LastInstruction { get; set; } = null;

        public void InsertInstructions(string[] lines)
        {
            var currentPosition = 0;
            foreach (var line in lines)
            {
                var input = line.Split(" ");
                var argument = int.Parse(input[1]);
                Instructions.Add(new Instruction(currentPosition, input[0], argument));
                currentPosition++;
            }
        }

        public void RunBootCode()
        {
            while (!Instructions.Last().Executed)
            {
                var possibleInstructionToBeChanged = Instructions.Where(x => x.Operation.Equals("nop") || x.Operation.Equals("jmp")).ToList();
                var changedInstruction = possibleInstructionToBeChanged.Where(x => x.Changed == true).LastOrDefault();
                if (changedInstruction != null && changedInstruction.Changed == true)
                {
                    changedInstruction.Operation = changedInstruction.Operation.Equals("nop") ? "jmp" : "nop";
                }
                var nextInstructionToBeChanged = possibleInstructionToBeChanged.Where(x => x.Changed == false).FirstOrDefault();
                if (nextInstructionToBeChanged != null)
                {
                    nextInstructionToBeChanged.Operation = nextInstructionToBeChanged.Operation.Equals("nop") ? "jmp" : "nop";
                    nextInstructionToBeChanged.Changed = true;
                }
                var nextOperationAvailable = true;
                while (nextOperationAvailable)
                {
                    nextOperationAvailable = ExecuteNextOperation();
                }
                if (!Instructions.Last().Executed)
                {
                    Instructions.ForEach(x => x.Executed = false);
                    Accumulator = 0;
                    Position = 0;
                }
            }
            Console.WriteLine("Accumulator is: " + Accumulator);
        }

        private bool ExecuteNextOperation()
        {
            var instruction = Instructions.Where(x => x.Position == Position && !x.Executed).FirstOrDefault();
            switch(instruction?.Operation)
            {
                case "nop":
                    Position++;
                    instruction.Executed = true;
                    LastInstruction = instruction;
                    return true;
                case "acc":
                    Position++;
                    Accumulator += instruction.Argument;
                    instruction.Executed = true;
                    return true;
                case "jmp":
                    Position += instruction.Argument;
                    instruction.Executed = true;
                    LastInstruction = instruction;
                    return true;
                default:
                    return false;
            }
        }
    }
}
