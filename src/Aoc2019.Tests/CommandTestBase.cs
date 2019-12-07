using System.Collections.Generic;
using Aoc2019.Commands;

namespace Aoc2019.Tests
{
    public abstract class CommandTestBase
    {
        protected Dictionary<string, object> Data;
        protected Command Cmd;
        protected static string DataKey = "key";

        protected CommandTestBase()
        {
            Data = new Dictionary<string, object>();
        }
    }
}