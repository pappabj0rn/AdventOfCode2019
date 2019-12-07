using System;
using System.Linq;
using Aoc2019.IntcodeComputer.Instructions;

namespace Aoc2019.IntcodeComputer
{
    public interface IInstructionDecoder
    {
        void Decode(ComputerState state);
    }

    public class InstructionDecoder : IInstructionDecoder
    {
        private readonly Instruction[] _instructions;

        public InstructionDecoder(Instruction[] instructions)
        {
            _instructions = instructions;
        }

        public void Decode(ComputerState state)
        {
            var instructionCode = state.Memory[state.ProgramCounter];

            var pmString = Math.DivRem(instructionCode, 100, out int opCode)
                .ToString();

            state.Instruction = _instructions.FirstOrDefault(x=>x.OpCode == opCode);

            if (state.Instruction is null)
            {
                state.Halt = true;
                state.InstructionDecodeError = true;
                return;
            }

            state.Instruction.ParameterModes = Convert.ToInt32(pmString, 2);
        }
    }
}
