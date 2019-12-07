using System.Linq;
using Aoc2019.Commands;
using Xunit;

namespace Aoc2019.Tests
{
    public abstract class PwdKrackz0rTests : CommandTestBase
    {
        protected PwdKrackz0rTests()
        {
            Cmd = new PwdKrackz0r(DataKey);
        }

        public class ExecuteV1 : PwdKrackz0rTests
        {
            [Fact]
            public void Should_filter_options_less_than_100000()
            {
                Data.Add(DataKey, new[] { 99999, 111111 });

                Cmd.Execute(Data);

                var matchingPasswordsInRange = (int[])Data[PwdKrackz0r.CandidatesV1Key];

                Assert.Equal(111111, matchingPasswordsInRange.Last());
            }

            [Fact]
            public void Should_filter_options_greater_than_999999()
            {
                Data.Add(DataKey, new[] { 999999, 1000000 });

                Cmd.Execute(Data);

                var matchingPasswordsInRange = (int[])Data[PwdKrackz0r.CandidatesV1Key];

                Assert.Single(matchingPasswordsInRange);
                Assert.Equal(999999, matchingPasswordsInRange[0]);
            }

            [Fact]
            public void Should_filter_options_with_decreasing_pairs()
            {
                Data.Add(DataKey,new[]{111110,111111});

                Cmd.Execute(Data);

                var matchingPasswordsInRange = (int[]) Data[PwdKrackz0r.CandidatesV1Key];

                Assert.Single(matchingPasswordsInRange);
                Assert.Equal(111111,matchingPasswordsInRange[0]);
            }

            [Fact]
            public void Should_filter_options_with_no_adjacent_twins()
            {
                Data.Add(DataKey, new[] { 123788, 123789 });

                Cmd.Execute(Data);

                var matchingPasswordsInRange = (int[])Data[PwdKrackz0r.CandidatesV1Key];
                Assert.Single(matchingPasswordsInRange);
                Assert.Equal(123788, matchingPasswordsInRange[0]);
            }
        }

        public class ExecuteV2 : PwdKrackz0rTests
        {
            [Theory]
            [InlineData(112233,true)]
            [InlineData(123444,false)]
            [InlineData(111122,true)]
            [InlineData(166678,false)]
            [InlineData(166677,true)]
            public void Should_filter_options_where_twin_is_part_of_larger_group(int input, bool allowed)
            {
                Data.Add(DataKey, new[] { input, input });

                Cmd.Execute(Data);

                var matchingPasswordsInRange = (int[])Data[PwdKrackz0r.CandidatesV2Key];

                if(allowed)
                    Assert.Contains(input, matchingPasswordsInRange);
                else
                    Assert.Empty(matchingPasswordsInRange);
            }
        }
    }
}