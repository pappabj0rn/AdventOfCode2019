using System.Collections.Generic;
using Aoc2019.IntcodeComputer.Instructions;

namespace Aoc2019.IntcodeComputer
{
    public class ComputerBuilder
    {
        private List<Instruction> instructions = new List<Instruction>();

        public ComputerBuilder UseAllInstructions()
        {
            instructions.Add(new Add());
            instructions.Add(new Multiply());
            instructions.Add(new Input());
            instructions.Add(new Output());
            instructions.Add(new JumpIfTrue());
            instructions.Add(new JumpIfFalse());
            instructions.Add(new LessThan());
            instructions.Add(new Equals());
            instructions.Add(new Halt());

            return this;
        }

        public Computer Build()
        {
            if (instructions.Count == 0)
                UseAllInstructions();

            var decoder = new InstructionDecoder(instructions.ToArray());
            return new Computer(decoder);
        }
    }
}
