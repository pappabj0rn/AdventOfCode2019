using Aoc2019.IntcodeComputer.Instructions;

namespace Aoc2019.IntcodeComputer
{
    public class ComputerState
    {
        public bool Halt { get; set; }
        public bool InstructionDecodeError { get; set; }

        public int ProgramCounter { get; set; }
        public int[] Memory { get; set; }

        public int Input { get; set; }
        public int Output { get; set; }
        public Instruction Instruction { get; set; }
    }
}