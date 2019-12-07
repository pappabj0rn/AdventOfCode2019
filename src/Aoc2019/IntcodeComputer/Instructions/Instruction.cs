namespace Aoc2019.IntcodeComputer.Instructions
{
    public abstract class Instruction
    {
        public abstract int OpCode { get; }
        public int Length => 1 + ParameterCount;
        public abstract int ParameterCount { get; }
        public int ParameterModes { get; set; }

        public void Execute(ComputerState state)
        {
            ExecuteInternal(state);
            state.ProgramCounter += Length;
        }

        protected abstract void ExecuteInternal(ComputerState state);

        protected int GetParameterValue(int parameter, ComputerState state)
        {
            return (ParameterModes & (1 << (parameter - 1))) > 0 
                ? state.Memory[state.ProgramCounter + parameter] 
                : state.Memory[state.Memory[state.ProgramCounter + parameter]];
        }

        protected void Write(int value, ComputerState state, int addrOffset)
        {
            state.Memory[state.Memory[state.ProgramCounter + addrOffset]] = value;
        }
    }
}