using System.Collections.Generic;

namespace Aoc2019
{
    public class Prg1202NounVerbFinder : Command
    {
        public static string ProgramKey = "Prg1202NounVerbFinder";
        public static string FoundNounKey = "Prg1202NounVerbFinderNoun";
        public static string FoundVerbKey = "Prg1202NounVerbFinderVerb";

        private readonly string _orgProgramKey;
        private readonly int _wantedResult;
        private readonly Command _intcodeParser;

        public Prg1202NounVerbFinder(
            string orgProgramKey, 
            int wantedResult, 
            Command intcodeParser)
        {
            _orgProgramKey = orgProgramKey;
            _wantedResult = wantedResult;
            _intcodeParser = intcodeParser;
        }

        public override void Execute(Dictionary<string, object> data)
        {
            var prg = (int[])((int[])data[_orgProgramKey]).Clone();
            var found = false;

            for (var noun = 0; noun < 100; noun++)
            {
                if (found)
                    break;

                for (var verb = 0; verb < 100; verb++)
                {
                    if (found)
                        break;

                    var prgItteration = (int[])prg.Clone();
                    prgItteration[1] = noun;
                    prgItteration[2] = verb;

                    var internalData = new Dictionary<string, object>
                    {
                        {ProgramKey, prgItteration}
                    };

                    _intcodeParser.Execute(internalData);

                    if (((int[]) internalData[ProgramKey])[0] != _wantedResult)
                        continue;

                    data.Add(FoundNounKey, noun);
                    data.Add(FoundVerbKey, verb);
                    found = true;
                }
            }
        }
    }
}