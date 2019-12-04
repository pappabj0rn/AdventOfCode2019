using Xunit;

namespace Aoc2019.Tests
{
    public abstract class WireIntersectionFinderTest : CommandTestBase
    {
        private static string DataKey = "key";

        protected WireIntersectionFinderTest()
        {
            Cmd = new WireIntersectionFinder(DataKey);
        }

        public class Execute : WireIntersectionFinderTest
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
            public void Should_find_closes_manhattan_distance_where_wires_intersect(
                int expectedManhattanDistance, 
                params string[] wireData)
            {
                Data.Add(DataKey, wireData);

                Cmd.Execute(Data);

                Assert.Equal(
                    expectedManhattanDistance,
                    Data[WireIntersectionFinder.ClosesManhattanIntersectionKey]);
            }

            [Theory]
            [InlineData(4,
                "U1,R2",
                "R1,U2")]
            [InlineData(30,
                "R8,U5,L5,D3",
                "U7,R6,D4,L4")]
            [InlineData(610,
                "R75,D30,R83,U83,L12,D49,R71,U7,L72",
                "U62,R66,U55,R34,D71,R55,D58,R83")]
            [InlineData(410,
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51",
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7")]
            public void Should_find_shortest_route_distance_to_an_intersection(
                int expectedRouteDistance,
                params string[] wireData)
            {
                Data.Add(DataKey, wireData);

                Cmd.Execute(Data);

                Assert.Equal(
                    expectedRouteDistance,
                    Data[WireIntersectionFinder.ShortestRouteDistanceIntersectionKey]);
            }
        }
    }
}
