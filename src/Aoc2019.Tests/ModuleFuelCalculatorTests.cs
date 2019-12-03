using System.Collections.Generic;
using Xunit;

namespace AOC2019.Tests
{
    public abstract class ModuleFuelCalculatorTests
    {
        public class Execute : ModuleFuelCalculatorTests
        {
            private readonly Dictionary<string, object> _data;

            public Execute()
            {
                _data = new Dictionary<string, object>();
            }

            [Fact]
            public void Should_add_entry_for_module_fuel_weight_into_data_dictionary()
            {
                _data.Add(Global.ModuleWeightKey, new[] { 0 });
                var cmd = new ModuleFuelCalculator();
                cmd.Execute(_data);

                Assert.Contains(ModuleFuelCalculator.DataKey, _data.Keys);
            }

            [Theory]
            [InlineData(12, 2)]
            [InlineData(14,2)]
            [InlineData(1969,654)]
            [InlineData(100756,33583)]
            public void Should_calculate_module_fuel_according_to_example(int input, int output)
            {
                _data.Add(Global.ModuleWeightKey, new[]{input});
                var cmd = new ModuleFuelCalculator();
                cmd.Execute(_data);

                Assert.Equal(output, ModuleFuelData[0]);
            }

            public int[] ModuleFuelData => (int[])_data[ModuleFuelCalculator.DataKey];

            [Fact]
            public void Should_sum_module_fuel_and_add_into_data_dictionary()
            {
                _data.Add(Global.ModuleWeightKey, new[] { 12,12 });
                var cmd = new ModuleFuelCalculator();
                cmd.Execute(_data);

                Assert.Equal(2+2, ModuleFuelSum);
            }

            public int ModuleFuelSum => (int)_data[ModuleFuelCalculator.DataSumKey];
        }
    }
}
