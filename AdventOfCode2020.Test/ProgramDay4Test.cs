using AdventOfCode2020.Day4;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Test
{
    public class ProgramDay4Test
    {
        [Fact]
        public void ValidPassportsTest()
        {
            // Arrange
            var day4 = new ProgramDay4(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020.Test\Files\day4.txt");
            var expectedResultPassports = 8;
            var expectedResultPassportsValid = 4;

            // Act
            day4.ConvertInputToPassportList();
            var actualResult = day4.ReturnValidPassports();

            // Assert
            Assert.Equal(expectedResultPassports, day4.Passports.Count);
            Assert.Equal(expectedResultPassportsValid, actualResult);
        }
    }
}
