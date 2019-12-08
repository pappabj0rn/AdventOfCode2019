using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;
using Xunit;

namespace Aoc2019.Tests.IntcodeComputer.Instructions
{
    public abstract class JumpIfFalseTests : InstructionTestBase
    {
        protected JumpIfFalseTests()
        {
            TestedInstruction = new JumpIfFalse();
        }

        public class Execute : JumpIfFalseTests
        {
            [Theory]
            [InlineData(0b00, new[] { 0, 0, 3, 9 }, 9)]
            [InlineData(0b00, new[] { 0, 2, 3, 9 }, 3)]
            [InlineData(0b01, new[] { 0, 0, 3, 9 }, 9)]
            [InlineData(0b01, new[] { 0, 1, 3, 9 }, 3)]
            [InlineData(0b10, new[] { 0, 0, 9, 0 }, 9)]
            [InlineData(0b10, new[] { 1, 0, 9, 0 }, 3)]
            [InlineData(0b11, new[] { 0, 0, 9, 0 }, 9)]
            [InlineData(0b11, new[] { 0, 1, 9, 0 }, 3)]
            public void Should_set_program_counter_to_p2_when_p1_is_zero(
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

                Assert.Equal(expected, state.ProgramCounter);
            }
        }
    }
}