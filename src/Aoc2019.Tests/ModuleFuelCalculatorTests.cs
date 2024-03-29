﻿using Aoc2019.Commands;
using Xunit;

namespace Aoc2019.Tests
{
    public abstract class ModuleFuelCalculatorTests : CommandTestBase
    {
        public static string ModuleWeightKey = "mwk";

        protected ModuleFuelCalculatorTests()
        {
            Cmd = new ModuleFuelCalculator(ModuleWeightKey);
        }

        public class Execute : ModuleFuelCalculatorTests
        {
            [Fact]
            public void Should_add_entries_for_module_fuel_weight_into_data_dictionary()
            {
                Data.Add(ModuleWeightKey, new[] { 0 });
                Cmd.Execute(Data);

                Assert.Contains(ModuleFuelCalculator.DataKey, Data.Keys);
                Assert.Contains(ModuleFuelCalculator.DataSumKey, Data.Keys);
            }

            [Theory]
            [InlineData(12, 2)]
            [InlineData(14,2)]
            [InlineData(1969,654)]
            [InlineData(100756,33583)]
            public void Should_calculate_module_fuel_according_to_example(int input, int output)
            {
                Data.Add(ModuleWeightKey, new[]{input});
                Cmd.Execute(Data);

                Assert.Equal(output, ModuleFuelData[0]);
            }

            public int[] ModuleFuelData => (int[])Data[ModuleFuelCalculator.DataKey];

            [Fact]
            public void Should_sum_module_fuel_and_add_into_data_dictionary()
            {
                Data.Add(ModuleWeightKey, new[] { 12,12 });
                Cmd.Execute(Data);

                Assert.Equal(2+2, ModuleFuelSum);
            }

            public int ModuleFuelSum => (int)Data[ModuleFuelCalculator.DataSumKey];
        }
    }
}
