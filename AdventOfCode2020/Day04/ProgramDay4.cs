using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode2020.Day4
{
    public class ProgramDay4
    {
        public string[] Input { get; set; }
        public List<Passport> Passports { get; set; } = new List<Passport>();

        public ProgramDay4(string path)
        {
            Input = System.IO.File.ReadAllText(path).Split("\r\n");
        }

        public void ConvertInputToPassportList()
        {
            var timer = new Stopwatch();
            timer.Start();
            var newPassport = new Passport();
            foreach (var line in Input)
            {
                var passportContent = line.Split(' ');
                foreach (var field in passportContent)
                {
                    var keyValue = field.Split(':');
                    switch (keyValue[0])
                    {
                        case "byr":
                            newPassport.BirthYear = int.Parse(keyValue[1]);
                            break;
                        case "iyr":
                            newPassport.IssueYear = int.Parse(keyValue[1]);
                            break;
                        case "eyr":
                            newPassport.ExpirationYear = int.Parse(keyValue[1]);
                            break;
                        case "hgt":
                            newPassport.Height = keyValue[1];
                            break;
                        case "hcl":
                            newPassport.HairColor = keyValue[1];
                            break;
                        case "ecl":
                            newPassport.EyeColor = keyValue[1];
                            break;
                        case "pid":
                            newPassport.PassportId = keyValue[1];
                            break;
                        case "cid":
                            newPassport.CountryId = keyValue[1];
                            break;
                        case "":
                            Passports.Add(newPassport);
                            newPassport = new Passport();
                            break;
                        default:
                            break;
                    }
                }
            }
            Passports.Add(newPassport);
            timer.Stop();
            Console.WriteLine($"Duration of creating list Of Passports: {timer.ElapsedMilliseconds}");
        }

        public int ReturnValidPassports()
        {
            var counter = 0;
            foreach (var passport in Passports)
            {
                if (passport.IsValid())
                {
                    counter++;
                    Console.WriteLine(passport.ToString());
                }
                    
            }
            Console.WriteLine("Valid Passports: " + counter);
            return counter;
        }
    }
}
