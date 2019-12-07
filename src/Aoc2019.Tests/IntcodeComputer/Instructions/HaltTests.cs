using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;
using Xunit;

namespace Aoc2019.Tests.IntcodeComputer.Instructions
{
    public abstract class HaltTests : InstructionTestBase
    {
        protected HaltTests()
        {
            TestedInstruction = new Halt();
        }

        public class Execute : HaltTests
        {
            [Fact]
            public void Should_set_halt_to_true_on_state()
            {
                var state = new ComputerState();

                TestedInstruction.Execute(state);

                Assert.True(state.Halt);
            }
        }
    }
}