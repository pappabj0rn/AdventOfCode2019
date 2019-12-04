using System.Linq;
using Xunit;

namespace Aoc2019.Tests
{
    public abstract class PwdKrackz0rTests : CommandTestBase
    {
        protected PwdKrackz0rTests()
        {
            Cmd = new PwdKrackz0r(DataKey);
        }

        public class Execute : PwdKrackz0rTests
        {
            [Fact]
            public void Should_filter_options_less_than_100000()
            {
                Data.Add(DataKey, new[] { 99999, 111111 });

                Cmd.Execute(Data);

                var matchingPasswordsInRange = (int[])Data[PwdKrackz0r.CandidatesKey];

                Assert.Equal(111111, matchingPasswordsInRange.Last());
            }

            [Fact]
            public void Should_filter_options_greater_than_999999()
            {
                Data.Add(DataKey, new[] { 999999, 1000000 });

                Cmd.Execute(Data);

                var matchingPasswordsInRange = (int[])Data[PwdKrackz0r.CandidatesKey];

                Assert.Single(matchingPasswordsInRange);
                Assert.Equal(999999, matchingPasswordsInRange[0]);
            }

            [Fact]
            public void Should_filter_options_with_decreasing_pairs()
            {
                Data.Add(DataKey,new[]{111110,111111});

                Cmd.Execute(Data);

                var matchingPasswordsInRange = (int[]) Data[PwdKrackz0r.CandidatesKey];

                Assert.Single(matchingPasswordsInRange);
                Assert.Equal(111111,matchingPasswordsInRange[0]);
            }

            [Fact]
            public void Should_filter_options_with_no_adjacent_twins()
            {
                Data.Add(DataKey, new[] { 123788, 123789 });

                Cmd.Execute(Data);

                var matchingPasswordsInRange = (int[])Data[PwdKrackz0r.CandidatesKey];
                Assert.Single(matchingPasswordsInRange);
                Assert.Equal(123788, matchingPasswordsInRange[0]);
            }
        }
    }
}