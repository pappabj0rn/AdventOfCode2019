using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;
using Xunit;

namespace Aoc2019.Tests.IntcodeComputer.Instructions
{
    public abstract class AddTests : InstructionTestBase
    {
        protected AddTests()
        {
            TestedInstruction = new Add();
        }

        public class Execute : AddTests
        {
            [Fact]
            public void Should_in_addr_mode_add_values_at_addr1_and_addr2_and_write_to_addr3()
            {
                var in1 = 3;
                var in2 = 7;
                var state = new ComputerState
                {
                    Memory = new[]
                    {
                        in1,in2,TestedInstruction.OpCode,0,1,0
                    },
                    ProgramCounter = 2
                };

                TestedInstruction.Execute(state);

                Assert.Equal(
                    in1 + in2,
                    state.Memory[0]);
            }

            [Theory]
            [InlineData(0b00, new[] { 3, 7, 0, 1, 0 }, 1, 3 + 7)]
            [InlineData(0b01, new[] { 0, 6, 4, 1, 0 }, 1, 4 + 6)]
            [InlineData(0b10, new[] { 5, 0, 0, 5, 0 }, 1, 5 + 5)]
            [InlineData(0b11, new[] { 0, 0, 6, 3, 0 }, 1, 6 + 3)]
            public void Should_handle_mixed_parameter_modes(
                int parameterModes,
                int[] prg,
                int prgCounter,
                int expected)
            {
                TestedInstruction.ParameterModes = parameterModes;

                var state = new ComputerState
                {
                    Memory = prg,
                    ProgramCounter = prgCounter
                };

                TestedInstruction.Execute(state);

                Assert.Equal(expected, state.Memory[0]);
            }
        }
    }
}
