namespace Aoc2019.IntcodeComputer.Instructions
{
    public class Input : Instruction
    {
        public override int OpCode => 3;
        public override int ParameterCount => 1;

        protected override void ExecuteInternal(ComputerState state)
        {
            Write(state.Input,state,1);
        }
    }
}