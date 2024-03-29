﻿namespace Aoc2019.IntcodeComputer.Instructions
{
    public class Output : Instruction
    {
        public override int OpCode => 4;
        public override int ParameterCount => 1;

        protected override void ExecuteInternal()
        {
            State.Output.Add(GetParameterValue(1));
        }
    }
}