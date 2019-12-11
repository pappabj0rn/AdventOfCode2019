using System.Linq;
using Aoc2019.CalendarTasks;
using Xunit;

namespace Aoc2019.Tests.CalendarTasks
{
    public abstract class Day6Tests
    {
        public class Run : Day6Tests
        {
            [Theory]
            [InlineData(new[]{"COM)B", "B)C" }, 3)]
            [InlineData(new[]{"COM)B", "B)C", "B)D" }, 5)]
            [InlineData(new[]{"COM)B", "B)C", "C)D" }, 6)]
            [InlineData(new[]{ "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" }, 42)]
            public void Should_count_orbits_in_provided_example(
                string[] mapData, 
                int expectedCount)
            {
                var map = mapData.ToList();

                var task = new Day6 { Data = map };

                task.Run();

                Assert.Equal(expectedCount, task.Result[Day6.CountKey]);
            }

            [Theory]
            [InlineData(new[] { "COM)B", "B)YOU", "B)SAN" }, 0)]
            [InlineData(new[] { "COM)B", "B)YOU", "B)C", "C)SAN" }, 1)]
            [InlineData(new[] { "COM)B", "B)C", "B)D", "C)E", "D)YOU", "E)SAN" }, 3)]
            [InlineData(new[] { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN" }, 4)]
            public void Should_calculate_the_minimum_number_of_orbital_tranfers_to_get_from_YOU_to_SAN(
                string[] mapData, 
                int expectedJumps)
            {
                var map = mapData.ToList();

                var task = new Day6 { Data = map };

                task.Run();

                Assert.Equal(expectedJumps, task.Result[Day6.JumpCountKey]);
            }
        }
    }
}
