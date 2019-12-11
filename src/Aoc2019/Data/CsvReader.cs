using System;
using System.Linq;

namespace Aoc2019.Data
{
    public class CsvReader<T>
    {
        private readonly ITextFileReader _fileReader;

        public CsvReader(ITextFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public T[] Read()
        {
            var text = _fileReader.ReadAllText();

            return text
                .Split(',')
                .Select(x => (T) Convert.ChangeType(x, typeof(T)))
                .ToArray();
        }
    }
}
