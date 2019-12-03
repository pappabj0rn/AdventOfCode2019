using System;
using System.Collections.Generic;

namespace Aoc2019
{
    public class ModuleFuelFuelCalculator : Command
    {
        public static string DataKey = "ModuleFuelFuel";
        public static string DataSumKey = "ModuleFuelFuelSum";

        public override void Execute(Dictionary<string, object> data)
        {
            var list = new List<int>();
            var sum = 0;
            foreach (int fuelWeight in (IEnumerable<int>)data[ModuleFuelCalculator.DataKey])
            {
                var fuel = CalculateRequiredFuel(fuelWeight);
                list.Add(fuel);
                sum += fuel;
            }

            data.Add(DataKey, list.ToArray());
            data.Add(DataSumKey, sum);
        }

        private int CalculateRequiredFuel(int fuelWeight)
        {
            if (fuelWeight < 1)
                return 0;

            var fuel = (int) (fuelWeight / 3m - 2);
            return Math.Max(0, fuel + CalculateRequiredFuel(fuel));
        }
    }
}