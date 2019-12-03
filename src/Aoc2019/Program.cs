﻿using System;
using System.Collections.Generic;

namespace Aoc2019
{
    internal class Program
    {
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
            Console.WriteLine("\n");
        }

        private static IEnumerable<Command> CreateCommands()
        {
            return new List<Command>
            {
                new ModuleFuelCalculator(),
                new ModuleFuelFuelCalculator()
            };
        }

        private static Dictionary<string,object> LoadData()
        {
            var data = new Dictionary<string, object>();
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
            data.Add(Global.ModuleWeightKey, moduleWeights);
            return data;
        }
    }

    public static class Global
    {
        public static string ModuleWeightKey = "ModuleWeights";
    }
}
