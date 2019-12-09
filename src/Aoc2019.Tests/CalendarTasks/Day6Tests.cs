using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aoc2019.CalendarTasks;
using Aoc2019.Commands;
using Xunit;

namespace Aoc2019.Tests.CalendarTasks
{
    public abstract class Day6Tests
    {
        public class Execute : Day6Tests
        {
            [Theory]
            [InlineData(new[]{"COM)B", "B)C" }, 3)]
            [InlineData(new[]{"COM)B", "B)C", "B)D" }, 5)]
            [InlineData(new[]{"COM)B", "B)C", "C)D" }, 6)]
            [InlineData(new[]{ "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" }, 42)]
            public void Should_count_orbits_in_provided_example(
                string[] mapData, int expectedCount)
            {
                var map = mapData.ToList();

                var task = new Day6 { Data = map };

                task.Run();

                Assert.Equal(expectedCount, task.Result[Day6.CountKey]);
            }
        }
    }
}
