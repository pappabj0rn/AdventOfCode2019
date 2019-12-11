using System.Linq;
using Aoc2019.Data;
using Moq;
using Xunit;

namespace Aoc2019.Tests.Data
{
    public abstract class CsvReaderTests
    {
        protected Mock<ITextFileReader> textReaderMock = new Mock<ITextFileReader>();

        public class Read : CsvReaderTests
        {
            [Theory]
            [InlineData(new[] { 1 })]
            [InlineData(new[] { 1, 2, 3 })]
            [InlineData(new[] { -1, 99, 0, 45 })]
            public void Should_read_int_values(int[] expected)
            {
                var str = expected.Aggregate("", (c, n) => $"{c},{n}");
                textReaderMock
                    .Setup(x => x.ReadAllText())
                    .Returns(str.Substring(1));

                var csvReader = new CsvReader<int>(textReaderMock.Object);
                var actual = csvReader.Read();

                Assert.Equal(expected.Length, actual.Length);

                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.Equal(expected[i], actual[i]);
                }
            }

            [Theory]
            [InlineData("str")]
            [InlineData("str1,str2")]
            [InlineData("str1,str2,str3")]
            public void Should_read_strings_values(string input)
            {
                var expected = input.Split(',');
                var str = expected.Aggregate("", (c, n) => $"{c},{n}");
                textReaderMock
                    .Setup(x => x.ReadAllText())
                    .Returns(str.Substring(1));

                var csvReader = new CsvReader<string>(textReaderMock.Object);
                var actual = csvReader.Read();

                Assert.Equal(expected.Length, actual.Length);

                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.Equal(expected[i], actual[i]);
                }
            }
        }
    }
}
