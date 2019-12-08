namespace Aoc2019.IntcodeComputer.Instructions
{
    public class JumpIfTrue : Instruction
    {
        public override int OpCode => 5;
        public override int ParameterCount => 2;

        protected override void ExecuteInternal()
        {
            var jump = GetParameterValue(1) != 0;

            if (!jump) return;

            Jump(GetParameterValue(2));
        }
    }
}