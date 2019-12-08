using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;
using Xunit;

namespace Aoc2019.Tests.IntcodeComputer.Instructions
{
    public abstract class LessThanTests : InstructionTestBase
    {
        protected LessThanTests()
        {
            TestedInstruction = new LessThan();
        }

        public class Execute : LessThanTests
        {
            [Theory]
            [InlineData(0b00, new[] { 0, 0, 0, 4, -1 }, 0)]
            [InlineData(0b00, new[] { 0, 0, 1, 4, -1 }, 0)]
            [InlineData(0b00, new[] { 0, 0, 2, 4, -1 }, 1)]
            [InlineData(0b00, new[] { 0, 3, 2, 4, -1 }, 0)]
            [InlineData(0b11, new[] { 0, 0, 0, 4, -1 }, 0)]
            [InlineData(0b11, new[] { 0, 0, 1, 4, -1 }, 1)]
            [InlineData(0b11, new[] { 0, 1, 0, 4, -1 }, 0)]
            [InlineData(0b11, new[] { 0, 1, 1, 4, -1 }, 0)]
            public void Should_store_bool_at_addr3_showing_in1_less_than_in2(
                int parameterMode,
                int[] prg,
                int expected)
            {
                var state = new ComputerState
                {
                    Memory = prg
                };

                TestedInstruction.ParameterModes = parameterMode;

                TestedInstruction.Execute(state);

                Assert.Equal(expected, state.Memory[4]);
            }
        }
    }
}