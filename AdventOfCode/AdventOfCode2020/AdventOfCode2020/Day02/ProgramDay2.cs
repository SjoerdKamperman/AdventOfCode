using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day2
{
    public class ProgramDay2
    {
        public string[] Input { get; set; }
        public List<Password> Passwords { get; set; } = new List<Password>();

        public ProgramDay2(string path)
        {
            Input = System.IO.File.ReadAllLines(path);
        }

        public int ExecuteProgramOld()
        {
            foreach (var line in Input)
            {
                string[] inputPasswordViewModel = line.Split(' ');
                var passwordViewModel = new PasswordViewModel(inputPasswordViewModel[0], inputPasswordViewModel[1], inputPasswordViewModel[2]);
                Passwords.Add(passwordViewModel.ToModel());
            }

            var counterValidPasswords = 0;

            foreach (var password in Passwords)
            {
                if (password.IsValidOld())
                    counterValidPasswords++;
            }

            return counterValidPasswords;
        }

        public int ExecuteProgramNew()
        {
            foreach (var line in Input)
            {
                string[] inputPasswordViewModel = line.Split(' ');
                var passwordViewModel = new PasswordViewModel(inputPasswordViewModel[0], inputPasswordViewModel[1], inputPasswordViewModel[2]);
                Passwords.Add(passwordViewModel.ToModel());
            }

            var counterValidPasswords = 0;

            foreach (var password in Passwords)
            {
                if (password.IsValidNew())
                    counterValidPasswords++;
            }

            return counterValidPasswords;
        }
    }
}
