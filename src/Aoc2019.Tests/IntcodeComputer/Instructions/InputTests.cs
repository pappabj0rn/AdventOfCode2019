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
                    Input = 9
                };

                TestedInstruction.Execute(state);

                Assert.Equal(state.Input, state.Memory[prg[1]]);
            }
        }
    }
}