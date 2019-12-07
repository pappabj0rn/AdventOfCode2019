using System.Collections.Generic;
using Aoc2019.IntcodeComputer;
using Aoc2019.IntcodeComputer.Instructions;

namespace Aoc2019
{
    public class IntcodeParser : Command
    {
        private readonly string _programKey;

        public IntcodeParser(string programKey)
        {
            _programKey = programKey;
        }

        public override void Execute(Dictionary<string, object> data)
        {
            var decoder = new InstructionDecoder(new Instruction[]
            {
                new Add(),
                new Multiply(),
                new Halt()
            });

            var computer = new Computer(decoder);

            computer.State.Memory = (int[]) data[_programKey];

            computer.Run();
        }
    }
}