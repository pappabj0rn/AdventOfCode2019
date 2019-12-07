using System.Collections.Generic;

namespace Aoc2019.Commands
{
    public abstract class Command
    {
        public abstract void Execute(Dictionary<string, object> data);
    }
}