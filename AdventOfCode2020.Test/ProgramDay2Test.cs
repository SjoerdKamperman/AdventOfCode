using AdventOfCode2020.Day2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Test
{
    public class ProgramDay2Test
    {
        [Fact]
        public void ExecuteProgramOldTest()
        {
            // Arrange
            var day2 = new ProgramDay2(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020.Test\Files\day2.txt");
            var expectedResult = 2;

            // Act
            var actualResult = day2.ExecuteProgramOld();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ExecuteProgramNewTest()
        {
            // Arrange
            var day2 = new ProgramDay2(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020.Test\Files\day2.txt");
            var expectedResult = 1;

            // Act
            var actualResult = day2.ExecuteProgramNew();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
