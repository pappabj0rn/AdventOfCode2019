namespace Aoc2019.IntcodeComputer.Instructions
{
    public class JumpIfTrue : Instruction
    {
        public override int OpCode => 5;
        public override int ParameterCount => 2;

        protected override void ExecuteInternal(ComputerState state)
        {
            var jump = GetParameterValue(1, state) != 0;

            if (!jump) return;

            state.ProgramCounter = GetParameterValue(2, state) - Length;
        }
    }
}