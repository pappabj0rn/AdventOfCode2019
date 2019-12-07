using System;
using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;
using Xunit;

namespace Aoc2019.Tests.IntcodeComputer
{
    public abstract class InstructionDecoderTests
    {
        protected IInstructionDecoder Decoder;

        public class Decode : InstructionDecoderTests
        {
            public Decode()
            {
                var instructions = new Instruction[]
                {
                    new Add(),
                    new Multiply(),
                    new Halt()
                };

                Decoder = new InstructionDecoder(instructions);
            }

            [Theory]
            //          PPPOO
            [InlineData(00001, typeof(Add))]
            [InlineData(11101, typeof(Add))]
            [InlineData(00002, typeof(Multiply))]
            [InlineData(01002, typeof(Multiply))]
            [InlineData(00099, typeof(Halt))]
            public void Should_return_instruction_with_matching_opcode(int instruction, Type expectedInstructionType)
            {
                var state = BuildState(instruction);

                Decoder.Decode(state);

                Assert.Equal(
                    expectedInstructionType, 
                    state.Instruction.GetType());
            }

            [Theory]
            [InlineData(00001, 0)]
            [InlineData(00101, 1)]
            [InlineData(01001, 2)]
            [InlineData(01101, 3)]
            [InlineData(10001, 4)]
            [InlineData(10101, 5)]
            [InlineData(11001, 6)]
            [InlineData(11101, 7)]
            public void Should_set_parameter_modes_on_selected_instruction(int instruction, int paramModes)
            {
                var state = BuildState(instruction);

                Decoder.Decode(state);

                Assert.Equal(
                    paramModes, 
                    state.Instruction.ParameterModes);
            }

            [Fact]
            public void Should_halt_computer_and_set_InstructionDecodeError_flag_for_unknown_opcode()
            {
                var state = BuildState(88);
                Decoder.Decode(state);

                Assert.True(state.Halt);
                Assert.True(state.InstructionDecodeError);
            }

            private ComputerState BuildState(int instruction)
            {
                return new ComputerState
                {
                    Memory = new []{instruction}
                };
            }
        }
    }
}
