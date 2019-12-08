namespace Aoc2019.IntcodeComputer.Instructions
{
    public class Equals : Instruction
    {
        public override int OpCode => 8;
        public override int ParameterCount => 3;

        protected override void ExecuteInternal(ComputerState state)
        {
            var eq = GetParameterValue(1, state) == GetParameterValue(2, state);
            Write(eq ? 1 : 0, state, 3);
        }
    }
}