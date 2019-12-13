using System.Collections.Generic;
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
                    Inputs = new List<int> { 9 }
                };

                TestedInstruction.Execute(state);

                Assert.Equal(state.Inputs[0], state.Memory[prg[1]]);
            }

            [Fact]
            public void Should_use_inputs_in_sequence()
            {
                var input = new List<int> { 9, 5};
                var state = new ComputerState
                {
                    Memory = new[]{0,0,0,2},
                    Inputs = input
                };

                TestedInstruction.Execute(state);
                TestedInstruction.Execute(state);

                Assert.Equal(input, state.Inputs);
                Assert.Equal(9, state.Memory[0]);
                Assert.Equal(5, state.Memory[2]);
            }

            [Theory]
            [InlineData(new int[] { }, 1)]
            [InlineData(new[] { 1 }, 2)]
            [InlineData(new[] { 5, -5 }, 3)]
            public void Should_halt_and_set_awaitingInput_flag_when_input_is_requested_but_input_is_missing(
                int[] inputsAtStart,
                int executions)
            {
                var prg = AssembleTestProgram(executions);

                var state = new ComputerState
                {
                    Memory = prg.ToArray(),
                    Inputs = new List<int>(inputsAtStart)
                };

                for (int i = 0; i < executions; i++)
                {
                    TestedInstruction.Execute(state);
                }

                Assert.True(state.Halt, "State not halted.");
                Assert.True(state.AwaitingInput, "State not waiting for input.");
            }

            private static List<int> AssembleTestProgram(int executions, int instructionOpCode = 0)
            {
                var prg = new List<int>();
                for (var i = 0; i < executions; i++)
                {
                    prg.Add(instructionOpCode);
                    prg.Add(i * 2); //addr to storeInput
                }

                return prg;
            }

            [Theory]
            [InlineData(new int[] { }, 1)]
            [InlineData(new[] { 1 }, 2)]
            [InlineData(new[] { 5, -5 }, 3)]
            public void Should_write_existing_input_before_awaiting_more_input(
                int[] inputsAtStart,
                int executions)
            {
                var testOpCode = 1;
                var prg = AssembleTestProgram(executions, testOpCode);

                var state = new ComputerState
                {
                    Memory = prg.ToArray(),
                    Inputs = new List<int>(inputsAtStart)
                };

                for (int i = 0; i < executions; i++)
                {
                    TestedInstruction.Execute(state);
                }

                for (int i = 0; i < executions - 1; i++)
                {
                    Assert.Equal(inputsAtStart[i], state.Memory[i * 2]);
                }
                Assert.Equal(
                    testOpCode,
                    state.Memory[(executions - 1) * 2]);
            }

            [Theory]
            [InlineData(new int[] { }, 1, 9)]
            [InlineData(new[] { 1 }, 2, -7)]
            [InlineData(new[] { 5, -5 }, 3, 0)]
            public void Should_resume_reading_input_after_input_has_been_added(
                int[] inputsAtStart,
                int executions,
                int addedInput)
            {
                var testOpCode = 11;
                var prg = AssembleTestProgram(executions, testOpCode);

                var state = new ComputerState
                {
                    Memory = prg.ToArray(),
                    Inputs = new List<int>(inputsAtStart)
                };

                for (int i = 0; i < executions; i++)
                {
                    TestedInstruction.Execute(state);
                }

                state.Inputs.Add(addedInput);
                TestedInstruction.Execute(state);

                Assert.Equal(
                    addedInput,
                    state.Memory[(executions - 1) * 2]);
            }

            [Fact]
            public void Should_reset_halt_and_awaitingInput_flags_after_resuming_successfully()
            {
                var prg = AssembleTestProgram(1);

                var state = new ComputerState
                {
                    Memory = prg.ToArray()
                };

                TestedInstruction.Execute(state);
                state.Inputs.Add(1337);
                state.Halt = false;
                TestedInstruction.Execute(state);

                Assert.False(state.AwaitingInput, "State waiting for input.");
            }
        }
    }
}