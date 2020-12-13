
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day6
{
    public class Group
    {
        public List<char> AnswersYesDeclarationForm { get; set; } = new List<char>();
        public int GroupSize { get; set; } = 0;


        public int GetEveryoneAnsweredYes()
        {
            var groupedAnswers = AnswersYesDeclarationForm.GroupBy(x => x);
            var EveryoneAnsweredYes = groupedAnswers.Where(x => x.Count() == GroupSize).ToList();
            return EveryoneAnsweredYes.Count;
    }
    }

    
}
