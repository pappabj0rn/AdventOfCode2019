namespace Aoc2019.IntcodeComputer.Instructions
{
    public class LessThan : Instruction
    {
        public override int OpCode => 7;
        public override int ParameterCount => 3;

        protected override void ExecuteInternal(ComputerState state)
        {
            var lt = GetParameterValue(1, state) < GetParameterValue(2, state);
            Write(lt ? 1 : 0, state, 3);
        }
    }
}