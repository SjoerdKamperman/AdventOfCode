using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day2
{
    public class PasswordViewModel
    {
        public string NumberOfTimesGiven { get; set; }
        public string MandatoryCharacter { get; set; }
        public string Password { get; set; }

        public PasswordViewModel(string numberOfTimesGiven, string mandatoryCharacter, string password)
        {
            NumberOfTimesGiven = numberOfTimesGiven;
            MandatoryCharacter = mandatoryCharacter;
            Password = password;
        }

        public Password ToModel()
        {
            string[] splittedMinMaxCharacters = NumberOfTimesGiven.Split("-");
            var minimumCharacter = int.Parse(splittedMinMaxCharacters[0]);
            var maximumCharacter = int.Parse(splittedMinMaxCharacters[1]);

            var mandatoryCharacter = MandatoryCharacter[0];

            var passwordPolicy = new PasswordPolicy(minimumCharacter, maximumCharacter, mandatoryCharacter);

            return new Password(passwordPolicy, Password);
        }
    }
}
