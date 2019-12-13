using System;
using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;
using Xunit;

namespace Aoc2019.Tests.IntcodeComputer.Instructions
{
    public abstract class InstructionTests : InstructionTestBase
    {
        public class Execute : InstructionTests
        {
            private bool _executeInternalExecuted;

            public Execute()
            {
                TestedInstruction = new TestInstruction(0)
                {
                    ExecuteInternalAction = (self, givenState) =>
                    {
                        _executeInternalExecuted = true;
                    }
                };
            }

            [Fact]
            public void Should_call_ExecuteInternal_on_derived_class_with_given_state()
            {
                var state = new ComputerState();

                TestedInstruction.Execute(state);

                Assert.True(_executeInternalExecuted, "ExecuteInternal not called.");
            }

            [Fact]
            public void Should_advance_program_counter_with_length_of_instruction()
            {
                var state = new ComputerState
                {
                    Memory = new[] {0,0}
                };

                TestedInstruction.Execute(state);

                Assert.Equal(1,state.ProgramCounter);
            }

            [Fact]
            public void Should_advance_program_counter_if_instruction_jumped_in_previous_execution()
            {
                TestedInstruction = new TestInstruction(1)
                {
                    ExecuteInternalAction = (self, givenState) =>
                    {
                        var jmp = self.PublicGetParameterValue(1);
                        if (jmp > 0)
                            self.PublicJump(jmp);
                    },
                    ParameterModes = 1
                };

                var state = new ComputerState
                {
                    Memory = new[] { 0, 2, 1, 0 }
                };

                TestedInstruction.Execute(state);
                TestedInstruction.Execute(state);

                Assert.Equal(4, state.ProgramCounter);
            }
        }

        public class GetParameterValue : InstructionTests
        {
            private int _actual;

            public GetParameterValue()
            {
                TestedInstruction = new TestInstruction(3)
                {
                    ExecuteInternalAction = (self, givenState) =>
                    {
                        _actual = self.PublicGetParameterValue(givenState.Memory[0]);
                    }
                };
            }

            [Theory]
            [InlineData(new[] { 1, 4, 0, 0, 9 }, 9)]
            [InlineData(new[] { 2, 0, 4, 0, 9 }, 9)]
            [InlineData(new[] { 3, 0, 0, 4, 9 }, 9)]
            public void Should_handle_position_mode_for_parameters(
                int[] prg,
                int expected)
            {
                var state = new ComputerState
                {
                    Memory = prg
                };

                TestedInstruction.Execute(state);

                Assert.Equal(expected, _actual);
            }

            [Theory]
            [InlineData(new[]{1, 9, 2, 3}, 9)]
            [InlineData(new[]{2, 1, 9, 3}, 9)]
            [InlineData(new[]{3, 1, 3, 9}, 9)]
            public void Should_handle_immediate_mode_for_parameters(
                int[] prg,
                int expected)
            {
                var state = new ComputerState
                {
                    Memory = prg
                };

                TestedInstruction.ParameterModes = 1 << (prg[0] - 1);

                TestedInstruction.Execute(state);

                Assert.Equal(expected, _actual);
            }
        }

        internal class TestInstruction : Instruction
        {
            public override int OpCode => 0;
            public override int ParameterCount { get;  }

            public TestInstruction(int parameters)
            {
                ParameterCount = parameters;
            }

            public Action<TestInstruction, ComputerState> ExecuteInternalAction { get; set; }

            protected override void ExecuteInternal()
            {
                ExecuteInternalAction?.Invoke(this, State);
            }

            public int PublicGetParameterValue(int parameter)
            {
                return GetParameterValue(parameter);
            }

            public void PublicJump(int addr)
            {
                Jump(addr);
            }
        }
    }
}