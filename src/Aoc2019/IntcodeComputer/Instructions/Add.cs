namespace Aoc2019.IntcodeComputer.Instructions
{
    public class Add : Instruction
    {
        public override int OpCode => 1;
        public override int ParameterCount => 3;

        protected override void ExecuteInternal()
        {
            var value = GetParameterValue(1) + GetParameterValue(2);
            Write(value, State, 3);
        }
    }
}