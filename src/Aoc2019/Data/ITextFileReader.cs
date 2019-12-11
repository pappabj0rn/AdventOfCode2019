using System.Collections.Generic;

namespace Aoc2019.Data
{
    public interface ITextFileReader
    {
        string[] ReadAllLines();
        IEnumerable<string> ReadLines();
        string ReadAllText();
    }
}