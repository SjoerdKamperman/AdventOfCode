using AdventOfCode2020.Day3;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Test
{
    public class ProgramDay3Test
    {
        [Fact]
        public void ExecuteProgramOneTest()
        {
            // Arrange
            var day3 = new ProgramDay3(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020.Test\Files\day3.txt");
            var expectedResult = 336;

            // Act
            var option1 = day3.ExecuteProgramOne(1, 1);
            var option2 = day3.ExecuteProgramOne(3, 1);
            var option3 = day3.ExecuteProgramOne(5, 1);
            var option4 = day3.ExecuteProgramOne(7, 1);
            var option5 = day3.ExecuteProgramOne(1, 2);
            var actualResult = option1 * option2 * option3 * option4 * option5;

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
