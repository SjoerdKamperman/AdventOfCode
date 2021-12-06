using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day18
{
    public class ProgramDay18 : AOCPuzzle
    {
        public List<Sum> Sums { get; set; }

        public ProgramDay18(string path, int day) : base(path, day)
        {
        }

        private ulong doOp(Stack<ulong> stash, char op)
        {
            if (op == '+')
                return stash.Pop() + stash.Pop();
            else
                return stash.Pop() * stash.Pop();
        }

        private ulong eval(Queue<char> expression, Dictionary<char, int> precedence)
        {
            Stack<ulong> stash = new Stack<ulong>();
            Stack<char> ops = new Stack<char>();

            while (expression.Count > 0)
            {
                char c = expression.Dequeue();
                if (c >= '0' && c <= '9')
                    stash.Push((ulong)c - 48);
                else if (c == '(')
                    stash.Push(eval(expression, precedence));
                else if (c == ')')
                    break;
                else if (ops.Count == 0 || precedence[c] < precedence[ops.Peek()])
                    ops.Push(c);
                else
                {
                    stash.Push(doOp(stash, ops.Pop()));
                    ops.Push(c);
                }
            }

            while (ops.Count > 0)
                stash.Push(doOp(stash, ops.Pop()));

            return stash.Peek();
        }

        public void Solve()
        {
            var precPt1 = new Dictionary<char, int>() { ['+'] = 0, ['*'] = 0 };
            var precPt2 = new Dictionary<char, int>() { ['+'] = 0, ['*'] = 1 };
            ulong p1 = 0, p2 = 0;
            foreach (string line in Input)
            {
                p1 += eval(new Queue<char>(line.ToCharArray().Where(c => c != ' ')), precPt1);
                p2 += eval(new Queue<char>(line.ToCharArray().Where(c => c != ' ')), precPt2);
            }
            Console.WriteLine($"P1: {p1}");
            Console.WriteLine($"P2: {p2}");
        }

        public override void SolveOne()
        {
            throw new NotImplementedException();
        }

        public override void SolveTwo()
        {
            throw new NotImplementedException();
        }

        private int ExecuteSum(int currentTotal, char number, char sumOperator)
        {
            return sumOperator.Equals('*') ? currentTotal *= number : currentTotal += number;
        }
    }
}
