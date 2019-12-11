using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;
using Xunit;

namespace Aoc2019.Tests.IntcodeComputer.Instructions
{
    public abstract class InputTests : InstructionTestBase
    {
        protected InputTests()
        {
            TestedInstruction = new Input();
        }

        public class Execute : InputTests
        {
            [Theory]
            [InlineData(new[] { 0, 0 })]
            [InlineData(new[] { 0, 1 })]
            [InlineData(new[] { 0, 2, 0 })]
            public void Should_store_state_input_at_addr1(
                int[] prg)
            {
                var state = new ComputerState
                {
                    Memory = (int[])prg.Clone(),
                    Inputs = new[] {9}
                };

                TestedInstruction.Execute(state);

                Assert.Equal(state.Inputs[0], state.Memory[prg[1]]);
            }

            [Fact]
            public void Should_use_inputs_in_sequence()
            {
                var input = new[] {9, 5};
                var state = new ComputerState
                {
                    Memory = new[]{0,0,0,2},
                    Inputs = (int[])input.Clone()
                };

                TestedInstruction.Execute(state);
                TestedInstruction.Execute(state);

                Assert.Equal(input, state.Inputs);
                Assert.Equal(9, state.Memory[0]);
                Assert.Equal(5, state.Memory[2]);
            }
        }
    }
}