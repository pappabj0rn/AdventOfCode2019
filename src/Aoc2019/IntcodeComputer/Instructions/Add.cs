namespace Aoc2019.IntcodeComputer.Instructions
{
    public class Add : Instruction
    {
        public override int OpCode => 1;
        public override int ParameterCount => 3;

        protected override void ExecuteInternal(ComputerState state)
        {
            var value = GetParameterValue(1, state) + GetParameterValue(2, state);
            Write(value, state, 3);
        }
    }
}