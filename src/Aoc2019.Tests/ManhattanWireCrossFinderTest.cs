using Xunit;

namespace Aoc2019.Tests
{
    public abstract class ManhattanWireCrossFinderTest : CommandTestBase
    {
        private static string DataKey = "key";

        protected ManhattanWireCrossFinderTest()
        {
            Cmd = new ManhattanWireCrossFinder(DataKey);
        }

        public class Execute : ManhattanWireCrossFinderTest
        {
            [Theory]
            [InlineData(2,
                "U1,R2",
                "R1,U2")]
            [InlineData(6,
                "R8,U5,L5,D3",
                "U7,R6,D4,L4")]
            [InlineData(159, 
                "R75,D30,R83,U83,L12,D49,R71,U7,L72", 
                "U62,R66,U55,R34,D71,R55,D58,R83")]
            [InlineData(135, 
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", 
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7")]
            public void Should_find_closes_manhattan_distance_where_wires_cross(
                int expectedManhattanDistance, 
                params string[] wireData)
            {
                Data.Add(DataKey, wireData);

                Cmd.Execute(Data);

                Assert.Equal(
                    expectedManhattanDistance,
                    Data[ManhattanWireCrossFinder.ClosesManhattanIntersectionKey]);
            }
        }
    }
}