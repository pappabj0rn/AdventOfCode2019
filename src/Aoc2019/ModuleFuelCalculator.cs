using System.Collections.Generic;

namespace AOC2019
{
    public class ModuleFuelCalculator : Command
    {
        public static string DataKey = "ModuleFuel";
        public static string DataSumKey = "ModuleFuelSum";

        public override void Execute(Dictionary<string, object> data)
        {
            var list = new List<int>();
            var sum = 0;
            foreach (int moduleWeight in (IEnumerable<int>) data[Global.ModuleWeightKey])
            {
                var fuel = (int) (moduleWeight / 3m - 2);
                list.Add(fuel);
                sum += fuel;
            }

            data.Add(DataKey, list.ToArray());
            data.Add(DataSumKey, sum);
        }
    }
}