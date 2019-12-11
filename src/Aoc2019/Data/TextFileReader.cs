using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aoc2019.Data
{
    public class TextFileReader : ITextFileReader
    {
        private readonly string _path;
        private readonly Encoding _encoding;

        public TextFileReader(string path, Encoding encoding = null)
        {
            _path = path;
            _encoding = encoding ?? Encoding.ASCII;
        }

        public string[] ReadAllLines()
        {
            return File.ReadAllLines(_path, _encoding);
        }

        public IEnumerable<string> ReadLines()
        {
            return File.ReadLines(_path, _encoding);
        }

        public string ReadAllText()
        {
            return File.ReadAllText(_path,_encoding);
        }
    }
}