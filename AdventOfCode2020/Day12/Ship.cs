using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day12
{
    public class Ship
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public char CurrentDirection { get; set; } = 'E';
        public int WayPointX { get; set; } = 10;
        public int WayPointY { get; set; } = 1;

        public void ExecuteInstruction(Instruction instruction)
        {
            switch(instruction.Action)
            {
                case 'L':
                case 'R':
                    Turn(instruction);
                    break;
                case 'F':
                    MoveShip(instruction.Value);
                    break;
                default:
                    MoveWayPoint(instruction.Action, instruction.Value);
                    break;
                
            }
        }

        private void MoveShip(int value)
        {
            X += WayPointX * value;
            Y += WayPointY * value;
        }

        private void Turn(Instruction instruction)
        {
            switch (instruction.Action)
            {
                case 'R':
                    for (int i = 0; i < instruction.Value / 90; i++)
                    {
                        var temp = WayPointY;
                        WayPointY = WayPointX * -1;
                        WayPointX = temp;
                    }
                    break;
                case 'L':
                    for (int i = 0; i < instruction.Value / 90; i++)
                    {
                        var temp = WayPointY;
                        WayPointY = WayPointX;
                        WayPointX = temp * -1;
                    }
                    break;
            }
        }

        private void MoveWayPoint(char direction, int value)
        {
            switch(direction)
            {
                case 'N':
                    WayPointY += value;
                    break;
                case 'S':
                    WayPointY -= value;
                    break;
                case 'E':
                    WayPointX += value;
                    break;
                case 'W':
                    WayPointX -= value;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
