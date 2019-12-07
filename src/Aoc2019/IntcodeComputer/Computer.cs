namespace Aoc2019.IntcodeComputer
{
    public interface IComputer
    {
        ComputerState State { get; }
        void Run();
    }

    public class Computer : IComputer
    {
        public ComputerState State { get; }

        private readonly IInstructionDecoder _instructionDecoder;

        public Computer(IInstructionDecoder instructionDecoder)
        {
            _instructionDecoder = instructionDecoder;
            State = new ComputerState();
        }

        public void Run()
        {
            while (!State.Halt)
            {
                _instructionDecoder.Decode(State);
                State.Instruction?.Execute(State);
            }
        }
    }
}