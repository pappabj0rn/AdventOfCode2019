using System.Collections.Generic;

namespace AOC2019
{
    public abstract class Command
    {
        public abstract void Execute(Dictionary<string, object> data);
    }
}