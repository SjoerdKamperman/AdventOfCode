using AdventOfCode2020.Day1;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Test
{
    public class ProgramDay1Test
    {
        [Fact]
        public void ExecuteExpenseReportSumOfTwoTest()
        {
            // Arrange
            var day1 = new ProgramDay1(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020.Test\Files\day1.txt");
            var expectedResult = 514579;

            // Act
            var actualResult = day1.ExecuteExpenseReportSumOfTwo();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ExecuteExpenseReportSumOfThreeTest()
        {
            // Arrange
            var day1 = new ProgramDay1(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020.Test\Files\day1.txt");
            var expectedResult = 241861950;

            // Act
            var actualResult = day1.ExecuteExpenseReportSumOfThree();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
