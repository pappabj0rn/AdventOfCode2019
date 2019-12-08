namespace Aoc2019.IntcodeComputer.Instructions
{
    public class LessThan : Instruction
    {
        public override int OpCode => 7;
        public override int ParameterCount => 3;

        protected override void ExecuteInternal()
        {
            var lt = GetParameterValue(1) < GetParameterValue(2);
            Write(lt ? 1 : 0, State, 3);
        }
    }
}