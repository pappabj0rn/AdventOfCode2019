using System.Collections.Generic;

namespace Aoc2019
{
    public class PwdKrackz0r : Command
    {
        public static string CandidatesKey = "PwdKrackz0r.Candidates";
        private readonly string _dataKey;

        public PwdKrackz0r(string dataKey)
        {
            _dataKey = dataKey;
        }

        public override void Execute(Dictionary<string, object> data)
        {
            var inputRange = (int[]) data[_dataKey];
            var candidates = new List<int>();

            for (int i = inputRange[0]; i < inputRange[1]+1; i++)
            {
                candidates.Add(i);
            }

            candidates
                .FilterLessThan(100000)
                .FilterGreaterThan(999999)
                .FilterDecreasingPairs()
                .FilterNoAdjacentTwins();

            data.Add(CandidatesKey, candidates.ToArray());
        }
    }

    internal static class ListFilters
    {
        public static List<int> FilterLessThan(this List<int> list, int min)
        {
            for (int c = 0; c < list.Count; c++)
            {
                if (list[c] >= min)
                    continue;

                list.RemoveAt(c);
                c--;
            }
            return list;
        }

        public static List<int> FilterGreaterThan(this List<int> list, int max)
        {
            for (int c = 0; c < list.Count; c++)
            {
                if (list[c] <= max)
                    continue;

                list.RemoveAt(c);
                c--;
            }
            return list;
        }

        public static List<int> FilterDecreasingPairs(this List<int> list)
        {
            for (int c = 0; c < list.Count; c++)
            {
                var str = list[c].ToString();

                for (int i = 0; i < str.Length - 1; i++)
                {
                    var i1 = int.Parse(str[i].ToString());
                    var i2 = int.Parse(str[i + 1].ToString());

                    if (i2 >= i1)
                        continue;

                    list.RemoveAt(c);
                    c--;
                    break;
                }
            }

            return list;
        }

        public static List<int> FilterNoAdjacentTwins(this List<int> list)
        {
            for (int c = 0; c < list.Count; c++)
            {
                var str = list[c].ToString();

                var twinFound = false;
                for (int i = 0; i < str.Length - 1; i++)
                {
                    var i1 = int.Parse(str[i].ToString());
                    var i2 = int.Parse(str[i + 1].ToString());

                    if (i2 != i1)
                        continue;

                    twinFound = true;
                    break;
                }

                if (twinFound)
                    continue;

                list.RemoveAt(c);
                c--;
            }

            return list;
        }
    }
}