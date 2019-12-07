namespace Aoc2019.IntcodeComputer.Instructions
{
    public class Halt : Instruction
    {
        public override int OpCode => 99;
        public override int ParameterCount => 0;

        protected override void ExecuteInternal(ComputerState state)
        {
            state.Halt = true;
        }
    }
}