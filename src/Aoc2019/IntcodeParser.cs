using System.Collections.Generic;

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
            var opCodes = new Dictionary<int, Instruction>
            {
                {1, new Add()},
                {2, new Mul()},
                {99, new End()}
            };

            var state = new ProgramState
            {
                Memory = (int[]) data[_programKey]
            };

            while (!state.Done)
            {
                opCodes[state.Memory[state.ProgramCounter]]
                    .Execute(state);
            }
        }

        public class ProgramState
        {
            public bool Done { get; set; }
            public int ProgramCounter { get; set; }
            public int[] Memory { get; set; }
        }

        public abstract class Instruction
        {
            public virtual int Length { get; } = 0;

            public void Execute(ProgramState state)
            {
                ExecuteInternal(state);
                state.ProgramCounter += Length;
            }

            protected abstract void ExecuteInternal(ProgramState state);
        }

        private class End : Instruction
        {
            protected override void ExecuteInternal(ProgramState state)
            {
                state.Done = true;
            }
        }

        private class Add : Instruction
        {
            public override int Length => 4;

            protected override void ExecuteInternal(ProgramState state)
            {
                var i = state.ProgramCounter;
                var p1Addr = state.Memory[i + 1];
                var p2Addr = state.Memory[i + 2];
                var storageAddr = state.Memory[i + 3];

                state.Memory[storageAddr] = 
                    state.Memory[p1Addr] 
                    + state.Memory[p2Addr];
            }
        }

        private class Mul : Instruction
        {
            public override int Length => 4;

            protected override void ExecuteInternal(ProgramState state)
            {
                var i = state.ProgramCounter;
                var p1Addr = state.Memory[i + 1];
                var p2Addr = state.Memory[i + 2];
                var storageAddr = state.Memory[i + 3];

                state.Memory[storageAddr] =
                    state.Memory[p1Addr]
                    * state.Memory[p2Addr];
            }
        }
    }
}