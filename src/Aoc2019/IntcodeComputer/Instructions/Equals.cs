namespace Aoc2019.IntcodeComputer.Instructions
{
    public class Equals : Instruction
    {
        public override int OpCode => 8;
        public override int ParameterCount => 3;

        protected override void ExecuteInternal()
        {
            var eq = GetParameterValue(1) == GetParameterValue(2);
            Write(eq ? 1 : 0, State, 3);
        }
    }
}