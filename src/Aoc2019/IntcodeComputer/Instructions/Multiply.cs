namespace Aoc2019.IntcodeComputer.Instructions
{
    public class Multiply : Instruction
    {
        public override int OpCode => 2;
        public override int ParameterCount => 3;

        protected override void ExecuteInternal()
        {
            var value = GetParameterValue(1) * GetParameterValue(2);
            Write(value, State, 3);
        }
    }
}