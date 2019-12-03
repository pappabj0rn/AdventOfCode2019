using System;
using System.Collections.Generic;

namespace Aoc2019
{
    internal class Program
    {
        private static string Prg1202 = "1202 program";
        private static int Day2_2_MagicNumber = 19690720;

        private static void Main()
        {
            Console.WriteLine("Advent of Code 2019 console app.");

            var data = LoadData();
            var cmds = CreateCommands();
            foreach (var cmd in cmds)
            {
                cmd.Execute(data);
            }

            Console.WriteLine($"Module fuel sum: {(int)data[ModuleFuelCalculator.DataSumKey]}");

            var reqFuelFuel = (int) data[ModuleFuelCalculator.DataSumKey]
                              +(int) data[ModuleFuelFuelCalculator.DataSumKey];
            Console.WriteLine($"Inluding req. fuel: {reqFuelFuel}");
            Console.WriteLine();

            Console.WriteLine($"1202 Program[0]: {((int[])data[Prg1202])[0]}");
            var noun = (int) data[Prg1202NounVerbFinder.FoundNounKey];
            var verb = (int) data[Prg1202NounVerbFinder.FoundVerbKey];
            var result = 100 * noun + verb;
            Console.WriteLine($"> nv({Day2_2_MagicNumber}): {result}");
            Console.WriteLine("\n");
        }

        private static IEnumerable<Command> CreateCommands()
        {
            return new List<Command>
            {
                new ModuleFuelCalculator(),
                new ModuleFuelFuelCalculator(),
                new Prg1202NounVerbFinder(Prg1202,Day2_2_MagicNumber,new IntcodeParser(Prg1202NounVerbFinder.ProgramKey)),
                new IntcodeParser(Prg1202)
            };
        }

        private static Dictionary<string,object> LoadData()
        {
            var moduleWeights = new[]
            {
                77355,
                115734,
                59983,
                106798,
                71384,
                112431,
                87261,
                98469,
                104485,
                63185,
                112442,
                90113,
                62805,
                77610,
                61459,
                55290,
                139325,
                58463,
                65173,
                95550,
                101228,
                70912,
                147516,
                62547,
                137966,
                53801,
                115927,
                133275,
                147358,
                126852,
                110379,
                107234,
                130258,
                127847,
                118167,
                122223,
                90956,
                141688,
                88278,
                54049,
                135498,
                123187,
                125149,
                61475,
                136691,
                133089,
                120734,
                112196,
                88342,
                94531,
                105013,
                118379,
                106009,
                78690,
                87934,
                75396,
                83546,
                64225,
                104813,
                127819,
                78321,
                107227,
                107651,
                139758,
                50150,
                55272,
                106774,
                68290,
                104639,
                140973,
                121498,
                89391,
                108435,
                73725,
                51004,
                104700,
                127297,
                91490,
                103583,
                128041,
                146250,
                142082,
                95475,
                65298,
                130514,
                92002,
                141553,
                126533,
                75251,
                143249,
                146307,
                50681,
                128266,
                109199,
                72487,
                50416,
                92153,
                120627,
                119192,
                56510
            };
            
            var prg1202 = new[]
            {
                1, 12, 2, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 13, 1, 19, 1, 19, 10, 23, 2, 10, 23, 27, 1, 27, 6,
                31, 1, 13, 31, 35, 1, 13, 35, 39, 1, 39, 10, 43, 2, 43, 13, 47, 1, 47, 9, 51, 2, 51, 13, 55, 1, 5, 55,
                59, 2, 59, 9, 63, 1, 13, 63, 67, 2, 13, 67, 71, 1, 71, 5, 75, 2, 75, 13, 79, 1, 79, 6, 83, 1, 83, 5, 87,
                2, 87, 6, 91, 1, 5, 91, 95, 1, 95, 13, 99, 2, 99, 6, 103, 1, 5, 103, 107, 1, 107, 9, 111, 2, 6, 111,
                115, 1, 5, 115, 119, 1, 119, 2, 123, 1, 6, 123, 0, 99, 2, 14, 0, 0
            };

            var data = new Dictionary<string, object>
            {
                {Global.ModuleWeightKey, moduleWeights},
                { Prg1202, prg1202}
            };

            return data;
        }
    }

    public static class Global
    {
        public static string ModuleWeightKey = "ModuleWeights";
    }
}
