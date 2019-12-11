using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Aoc2019.IntcodeComputer.Instructions;

namespace Aoc2019.IntcodeComputer
{
    public class ComputerState
    {
        public ComputerState()
        {
            Output = new List<int>();
        }

        public bool Halt { get; set; }
        public bool InstructionDecodeError { get; set; }

        public int ProgramCounter { get; set; }
        public int[] Memory { get; set; }

        public int[] Inputs { get; set; }
        public int InputIndex = 0;
        public int Input => Inputs[InputIndex++];

        public List<int> Output { get; set; }
        public Instruction Instruction { get; set; }
    }
}