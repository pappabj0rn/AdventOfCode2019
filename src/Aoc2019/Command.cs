using System.Collections.Generic;

namespace Aoc2019
{
    public abstract class Command
    {
        public abstract void Execute(Dictionary<string, object> data);
    }
}