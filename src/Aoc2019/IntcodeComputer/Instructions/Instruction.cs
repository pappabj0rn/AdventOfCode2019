namespace Aoc2019.IntcodeComputer.Instructions
{
    public abstract class Instruction
    {
        public abstract int OpCode { get; }
        public int Length => 1 + ParameterCount;
        public abstract int ParameterCount { get; }
        public int ParameterModes { get; set; }

        protected ComputerState State;
        private bool _jumped;

        public void Execute(ComputerState state)
        {
            State = state;

            ExecuteInternal();

            if (_jumped) return;

            state.ProgramCounter += Length;
        }

        protected abstract void ExecuteInternal();

        protected int GetParameterValue(int parameter)
        {
            return (ParameterModes & (1 << (parameter - 1))) > 0 
                ? State.Memory[State.ProgramCounter + parameter] 
                : State.Memory[State.Memory[State.ProgramCounter + parameter]];
        }

        protected void Write(int value, ComputerState state, int addrOffset)
        {
            state.Memory[state.Memory[state.ProgramCounter + addrOffset]] = value;
        }

        protected void Jump(int addr)
        {
            State.ProgramCounter = addr;
            _jumped = true;
        }
    }
}