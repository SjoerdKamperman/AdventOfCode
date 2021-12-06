using AdventOfCode.Shared;
using System;
using Xunit;

namespace AdventOfCode2021.Test
{
    public class TestDay02
    {
        public Day_02 Day { get; set; }

        public TestDay02()
        {
            Day = new Day_02();
        }

        [Fact]
        public void TestDay02_SolveOne()
        {
            Day.Solve_One();

            var expectedResult = "150";
            Assert.Equal(expectedResult, Day.Result);
        }

        [Fact]
        public void TestDay02_SolveTwo()
        {
            Day.Solve_Two();

            var expectedResult = "900";
            Assert.Equal(expectedResult, Day.Result);
        }
    }
}
