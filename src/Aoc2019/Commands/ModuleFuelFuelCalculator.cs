using System;
using System.Collections.Generic;

namespace Aoc2019.Commands
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
                var moduleSum = 0;
                var  reqFuel = fuelWeight;
                while (reqFuel > 0)
                {
                     reqFuel = Math.Max(0, MassFuelCalculator.Calculate(reqFuel));
                     moduleSum += reqFuel;
                }

                list.Add(moduleSum);
                sum += moduleSum;
            }

            data.Add(DataKey, list.ToArray());
            data.Add(DataSumKey, sum);
        }
    }
}