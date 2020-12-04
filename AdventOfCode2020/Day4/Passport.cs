using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day4
{
    public class Passport
    {
        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }
        public Stopwatch _Timer { get; set; } = new Stopwatch();

        public Passport(int? birthYear, int? issueYear, int? expirationYear, string height, string hairColor, string eyeColor, string passpordId, string countryId)
        {
            BirthYear = birthYear;
            IssueYear = issueYear;
            ExpirationYear = expirationYear;
            Height = height;
            HairColor = hairColor;
            EyeColor = eyeColor;
            PassportId = passpordId;
            CountryId = countryId;
        }

        public Passport()
        { }

        public bool IsValid()
        {
            _Timer.Start();
            List<string> eyeColors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            var valid = true;
            if (BirthYear == null || BirthYear < 1920 || BirthYear > 2002)
                valid = false;
            if (IssueYear == null || IssueYear < 2010 || IssueYear > 2020)
                valid = false;
            if (ExpirationYear == null || ExpirationYear < 2020 || ExpirationYear > 2030)
                valid = false;
            if (string.IsNullOrEmpty(Height) || !Regex.IsMatch(Height, @"^(\d*)(in|cm)$"))
            {
                valid = false;
            }
            else
            {
                if (Regex.IsMatch(Height, @"cm"))
                {
                    var heightInt = int.Parse(Regex.Match(Height, @"\d+").Value);
                    if (heightInt < 150 || heightInt > 193)
                        valid = false;
                }
                else if (Regex.IsMatch(Height, @"in"))
                {
                    var heightInt = int.Parse(Regex.Match(Height, @"\d+").Value);
                    if (heightInt < 59 || heightInt > 76)
                        valid = false;
                }
                else
                {
                    valid = false;
                }
            }
            
            if (string.IsNullOrEmpty(HairColor) || !Regex.IsMatch(HairColor, @"^#([a-f0-9]{6})$"))
                valid = false;
            if (string.IsNullOrEmpty(EyeColor) || !eyeColors.Contains(EyeColor))
                valid = false;
            if (string.IsNullOrEmpty(PassportId) || !Regex.IsMatch(PassportId, @"^\d{9}$"))
                valid = false;
            _Timer.Stop();
            return valid;
        }

        public override string ToString()
        {
            return $"Passport (Duration validation: {_Timer.ElapsedMilliseconds}) - BirthYear = {BirthYear}, IssueYear = {IssueYear}, ExpirationYear = {ExpirationYear}, Height = {Height}, " +
                $"HairColor = {HairColor}, EyeColor = {EyeColor}, PassportId = {PassportId}, CountryId = {CountryId}";
        }
    }
}
