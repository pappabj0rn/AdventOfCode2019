using System.Threading.Tasks.Dataflow;
using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;
using Xunit;

namespace Aoc2019.Tests.IntcodeComputer.Instructions
{
    public abstract class OutputTests : InstructionTestBase
    {
        protected OutputTests()
        {
            TestedInstruction = new Output();
        }

        public class Execute : OutputTests
        {
            [Theory]
            [InlineData(new[] { 1, 0 })]
            [InlineData(new[] { 0, 1 })]
            [InlineData(new[] { 0, 2, 1 })]
            public void Should_write_value_from_addr1_to_state_output(
                int[] prg)
            {
                var state = new ComputerState
                {
                    Memory = (int[])prg.Clone()
                };

                TestedInstruction.Execute(state);

                Assert.Equal(1, state.Output[0]);
            }

            [Fact]
            public void Should_handle_writing_multiple_output_values()
            {
                var state = new ComputerState
                {
                    Memory = new[]
                    {
                        1,0,
                        2,2,
                        3,4
                    }
                };

                TestedInstruction.Execute(state);
                TestedInstruction.Execute(state);
                TestedInstruction.Execute(state);

                Assert.Equal(1, state.Output[0]);
                Assert.Equal(2, state.Output[1]);
                Assert.Equal(3, state.Output[2]);
            }
        }
    }
}