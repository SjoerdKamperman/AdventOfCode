using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day2
{
    public class Password
    {
        public PasswordPolicy Policy { get; set; }
        public string SecretPassword { get; set; }

        public Password(PasswordPolicy policy, string secretPassword)
        {
            Policy = policy;
            SecretPassword = secretPassword;
        }

        public bool IsValidOld()
        {
            var characterOccurences = SecretPassword.Count(x => x == Policy.MandatoryCharacter);
            return characterOccurences >= Policy.MinimumCharacter && characterOccurences <= Policy.MaximumCharacter;
        }

        public bool IsValidNew()
        {
            string checkedCharacters = SecretPassword[Policy.MinimumCharacter-1].ToString() + SecretPassword[Policy.MaximumCharacter-1].ToString();
            var characterOccurences = checkedCharacters.Count(x => x == Policy.MandatoryCharacter);
            return characterOccurences == 1;
        }
    }

    public class PasswordPolicy
    {
        public int MinimumCharacter { get; set; }
        public int MaximumCharacter { get; set; }
        public char MandatoryCharacter { get; set; }

        public PasswordPolicy(int minimumCharacter, int maximumCharacter, char mandatoryCharacter)
        {
            MinimumCharacter = minimumCharacter;
            MaximumCharacter = maximumCharacter;
            MandatoryCharacter = mandatoryCharacter;
        }


    }
}
