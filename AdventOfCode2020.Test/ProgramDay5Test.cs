using AdventOfCode2020.Day5;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Test
{
    public class ProgramDay5Test
    {
        [Fact]
        public void ValidPassportsTest()
        {
            // Arrange
            var day5 = new ProgramDay5(@"C:\Users\skamperm\source\repos\AdventOfCode\AdventOfCode2020.Test\Files\day5.txt");
            var airplaine = new Airplane();
            airplaine.FillSeats(day5.Input);
            var expectedResultHighestSeat = 866;
            var expectedResultEmptySeat = 583;

            // Act
            var actualResultHighestSeat = airplaine.GetHighestSeatNumber();
            var actualResultEmptySeat = airplaine.FindEmptySeat();

            // Assert
            Assert.Equal(expectedResultHighestSeat, actualResultHighestSeat);
            Assert.Equal(expectedResultEmptySeat, actualResultEmptySeat);
        }
    }
}
