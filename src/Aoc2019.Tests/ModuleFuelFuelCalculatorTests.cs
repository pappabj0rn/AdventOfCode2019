using Aoc2019.Commands;
using Xunit;

namespace Aoc2019.Tests
{
    public abstract class ModuleFuelFuelCalculatorTests : CommandTestBase
    {
        protected ModuleFuelFuelCalculatorTests()
        {
            Cmd = new ModuleFuelFuelCalculator();
        }

        public class Execute : ModuleFuelFuelCalculatorTests
        {

            [Fact]
            public void Should_add_entries_for_module_fuels_fuel_weight_into_data_dictionary()
            {
                AddRequiredData(new[] { 0 });
                Cmd.Execute(Data);

                Assert.Contains(ModuleFuelFuelCalculator.DataKey, Data.Keys);
                Assert.Contains(ModuleFuelFuelCalculator.DataSumKey, Data.Keys);
            }

            [Theory]
            [InlineData(2, 0)]
            [InlineData(654, 312)]
            [InlineData(33583, 16763)]
            public void Should_calculate_required_fuel_for_each_modules_fule_requirement(int input, int output)
            {
                AddRequiredData(new[] { input });
                Cmd.Execute(Data);

                Assert.Equal(output, ModuleFuelsFuelData[0]);
            }

            [Fact]
            public void Should_sum_module_fuels_fuel_and_add_into_data_dictionary()
            {
                AddRequiredData(new[] { 654, 654 });
                Cmd.Execute(Data);

                Assert.Equal(312 + 312, ModuleFuelsFuelSum);
            }

            private void AddRequiredData(int[] value)
            {
                Data.Add(ModuleFuelCalculator.DataKey, value);
            }

            public int ModuleFuelsFuelSum => (int)Data[ModuleFuelFuelCalculator.DataSumKey];

            public int[] ModuleFuelsFuelData => (int[])Data[ModuleFuelFuelCalculator.DataKey];
        }
    }
}