using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;
using Moq;
using Xunit;

namespace Aoc2019.Tests.IntcodeComputer
{
    public abstract class ComputerTests
    {
        protected IComputer Computer;
        protected Mock<IInstructionDecoder> InstructionDecoderMock 
            = new Mock<IInstructionDecoder>();

        protected ComputerTests()
        {
            Computer = new Computer(InstructionDecoderMock.Object);
        }

        public class Run : ComputerTests
        {
            [Fact]
            public void Should_stop_execution_on_halt()
            {
                InstructionDecoderMock
                    .Setup(x => x.Decode(It.IsAny<ComputerState>()))
                    .Callback((ComputerState state) =>
                    {
                        state.Instruction = new Halt();
                    });

                Computer.State.Memory = new[] {0};

                AssertAsync
                    .CompletesIn(1, () => Computer.Run())
                    .Wait();

                Assert.True(Computer.State.Halt, "Not halted.");
            }

            [Fact]
            public void Should_halt_on_InstructionDecodeError()
            {
                InstructionDecoderMock
                    .Setup(x => x.Decode(It.IsAny<ComputerState>()))
                    .Callback((ComputerState state) =>
                    {
                        state.InstructionDecodeError = true;
                        state.Halt = true;
                    });

                Computer.State.Memory = new[] { 0 };

                Computer.Run();

                Assert.True(Computer.State.Halt, "Not halted.");
            }

            //todo halt on instruction exception
        }
    }
}