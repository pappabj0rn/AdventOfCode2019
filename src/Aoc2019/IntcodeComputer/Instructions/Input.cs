using System;

namespace Aoc2019.IntcodeComputer.Instructions
{
    public class Input : Instruction
    {
        public override int OpCode => 3;
        public override int ParameterCount => 1;

        protected override void ExecuteInternal()
        {
            try
            {
                State.AwaitingInput = false;
                State.NextInput();
                Write(State.Input, State, 1);
            }
            catch (Exception)
            {
                State.Halt = true;
                State.AwaitingInput = true;
                State.PrevInput();
                Jump(State.ProgramCounter);
            }
        }
    }
}