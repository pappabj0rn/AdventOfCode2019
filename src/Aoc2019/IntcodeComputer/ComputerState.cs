using System.Collections.Generic;
using Aoc2019.IntcodeComputer.Instructions;

namespace Aoc2019.IntcodeComputer
{
    public class ComputerState
    {
        public ComputerState()
        {
            Inputs = new List<int>();
            Output = new List<int>();
        }

        public bool Halt { get; set; }
        public bool AwaitingInput { get; set; }
        public bool InstructionDecodeError { get; set; }

        public int ProgramCounter { get; set; }
        public int[] Memory { get; set; }

        public List<int> Inputs { get; set; }
        private int _inputIndex = -1;
        public int Input => Inputs[_inputIndex];

        public void PrevInput()
        {
            _inputIndex--;
        }

        public void NextInput()
        {
            _inputIndex++;
        }

        public List<int> Output { get; set; }
        public Instruction Instruction { get; set; }
    }
}