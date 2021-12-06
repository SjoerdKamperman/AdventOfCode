using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode2020.Day6
{
    class ProgramDay6
    {
        public string[] Input { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();

        public ProgramDay6(string path)
        {
            Input = System.IO.File.ReadAllText(path).Split("\r\n");
        }


        public void ConvertInputToGroupAnswers()
        {
            var timer = new Stopwatch();
            timer.Start();
            var newGroup = new Group();
            foreach (var line in Input)
            {
                if (line.Equals(""))
                {
                    Groups.Add(newGroup);
                    newGroup = new Group();
                }
                else if (newGroup.GroupSize == 0)
                {
                    foreach (var character in line)
                    {
                        newGroup.AnswersYesDeclarationForm.Add(character);
                    }
                    newGroup.GroupSize++;
                } 
                else
                {
                    foreach (var character in line)
                    {
                        if (newGroup.AnswersYesDeclarationForm.Contains(character))
                        {
                            newGroup.AnswersYesDeclarationForm.Add(character);
                        }
                    }
                    newGroup.GroupSize++;
                }
                
            }
            Groups.Add(newGroup);
            timer.Stop();
            Console.WriteLine($"Duration of creating list Of Groups: {timer.ElapsedMilliseconds}");
        }

        public void SumUpAnsweredYes()
        {
            var sum = 0;
            foreach (var group in Groups)
            {
                sum += group.GetEveryoneAnsweredYes();
            }

            Console.WriteLine("Sum of answered yes = " + sum);
        }
    }
}
