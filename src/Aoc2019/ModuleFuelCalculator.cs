using System.Collections.Generic;

namespace Aoc2019
{
    public class ModuleFuelCalculator : Command
    {
        private readonly string _moduleWeightsKey;
        public static string DataKey = "ModuleFuel";
        public static string DataSumKey = "ModuleFuelSum";

        public ModuleFuelCalculator(string moduleWeightsKey)
        {
            _moduleWeightsKey = moduleWeightsKey;
        }

        public override void Execute(Dictionary<string, object> data)
        {
            var list = new List<int>();
            var sum = 0;
            foreach (int moduleWeight in (IEnumerable<int>) data[_moduleWeightsKey])
            {
                var fuel = MassFuelCalculator.Calculate(moduleWeight);
                list.Add(fuel);
                sum += fuel;
            }

            data.Add(DataKey, list.ToArray());
            data.Add(DataSumKey, sum);
        }
    }
}