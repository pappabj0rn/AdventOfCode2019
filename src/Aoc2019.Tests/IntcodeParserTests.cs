using Xunit;

namespace Aoc2019.Tests
{
    public abstract class IntcodeParserTests : CommandTestBase
    {
        private static string ProgramKey = "1202 Program";
        protected IntcodeParserTests()
        {
            Cmd = new IntcodeParser(ProgramKey);
        }

        public class Execute : IntcodeParserTests
        {
            [Theory]
            [InlineData(new[] {99},
                        new[] {99})]
            [InlineData(new[] {1,0,0,0,99},
                        new[] {2,0,0,0,99})]
            [InlineData(new[] {2,3,0,3,99},
                        new[] {2,3,0,6,99})]
            [InlineData(new[] {2,4,4,5,99,0},
                        new[] {2,4,4,5,99,9801})]
            [InlineData(new[] {1,1,1,4,99,5,6,0,99},
                        new[] {30,1,1,4,2,5,6,0,99})]
            public void Should_execute_sample_programs(int[] input, int[] output)
            {
                Data.Add(ProgramKey, input);

                Cmd.Execute(Data);

                Assert.Equal(output, Data[ProgramKey]);
            }
        }
    }


}