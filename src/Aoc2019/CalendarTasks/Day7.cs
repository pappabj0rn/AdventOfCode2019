using System;
using System.Collections.Generic;
using System.Linq;
using Aoc2019.IntcodeComputer;

namespace Aoc2019.CalendarTasks
{
    public class Day7 : CalendarTask
    {
        public static string ThrusterSignalKey = "day7.thrusterSignal";
        public static string PhaseSettingKey = "day7.phaseSettingKey";

        public override void Run()
        {
            var data = (DataModel) Data;

            var cb = new ComputerBuilder();

            var amps = new List<Computer>();

            for (int i = 0; i < 5; i++)
            {
                amps.Add(cb.Build());
            }

            var phasePermutations = data.PhaseSettings.Permutations();

            var maxThrusterSignal = 0;
            var withPS = new[] {0};
            foreach (var phaseSetting in phasePermutations)
            {
                foreach (var amp in amps)
                {
                    amp.State = new ComputerState
                    {
                        Memory = (int[]) data.Program.Clone()
                    };
                }

                var prevI = new[] {4, 0, 1, 2, 3};
                var ps = phaseSetting.ToArray();
                var iteration = 0;
                while(iteration > -1)
                {
                    for (int i = 0; i < ps.Length; i++)
                    {
                        if(iteration == 0)
                            amps[i].State.Inputs.Add(ps[i]);

                        amps[i].State.Inputs.Add(amps[prevI[i]].State.Output.LastOrDefault());
                        amps[i].State.Halt = false;
                        amps[i].Run();
                    }

                    if (data.FeedbackMode
                        && amps.Last().State.AwaitingInput)
                    {
                        iteration++;
                    }
                    else
                    {
                        iteration = -1;
                    }
                }

                var signal = amps[4].State.Output.Last();
                if (signal > maxThrusterSignal)
                {
                    maxThrusterSignal = signal;
                    withPS = ps;
                }
            }
            

            Result.Add(ThrusterSignalKey,maxThrusterSignal);
            Result.Add(PhaseSettingKey, withPS);
        }

        public class DataModel
        {
            public int[] Program { get; set; }
            public int[] PhaseSettings { get; set; }
            public bool FeedbackMode { get; set; }
        }
    }

    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            return PermutationsInternal(source.ToArray());
        }

        private static IEnumerable<IEnumerable<T>> PermutationsInternal<T>(IEnumerable<T> source)
        {
            var c = source.Count();
            if (c == 1)
                yield return source;

            else
                for (int i = 0; i < c; i++)
                    foreach (var p in PermutationsInternal(source.Take(i).Concat(source.Skip(i + 1))))
                        yield return source.Skip(i).Take(1).Concat(p);
        }
    }
}
