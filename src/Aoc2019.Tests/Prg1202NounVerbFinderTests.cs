using System;
using System.Collections.Generic;
using Aoc2019.Commands;
using Xunit;

namespace Aoc2019.Tests
{
    public abstract class Prg1202NounVerbFinderTests : CommandTestBase
    {
        private static string Prg1202Key = "prg";
        readonly TestCommand _testCommand = new TestCommand();

        protected Prg1202NounVerbFinderTests()
        {
            Data.Add(Prg1202Key, new[] { 1, 0, 0, 0, 99 });

            Cmd = new Prg1202NounVerbFinder(
                Prg1202Key, 
                TestCommand.MagicNumber, 
                _testCommand);
        }

        public class Execute : Prg1202NounVerbFinderTests
        {
            [Fact]
            public void Should_modify_given_programs_noun_and_verb_from_0_to_MagicNoun_and_MagicVerb()
            {
                Cmd.Execute(Data);

                for (int noun = 0; noun < TestCommand.MagicNoun; noun++)
                {
                    for (int verb = 0; verb < TestCommand.MagicVerb; verb++)
                    {
                        try
                        {
                            Assert.Contains(_testCommand.ExecutionInputs,
                                x => x.noun == noun && x.verb == verb);
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"Error at [{noun},{verb}]", e);
                        }
                    }
                }
            }

            [Fact]
            public void Should_store_noun_verb_combo_that_produces_the_magic_number()
            {
                Cmd.Execute(Data);

                Assert.Equal(TestCommand.MagicNoun,
                    Data[Prg1202NounVerbFinder.FoundNounKey]);
                Assert.Equal(TestCommand.MagicVerb,
                    Data[Prg1202NounVerbFinder.FoundVerbKey]);
            }

            [Fact]
            public void Should_stop_searching_once_magic_number_has_been_found()
            {
                Cmd.Execute(Data);

                var expectedItterations = 
                    (TestCommand.MagicNoun * 100) 
                    + (TestCommand.MagicVerb + 1);

                Assert.Equal(
                    expectedItterations,
                    _testCommand.ExecutionInputs.Count);
            }
        }
    }

    internal class TestCommand : Command
    {
        public const int MagicNumber = 19690720;
        public const int MagicNoun = 10;
        public const int MagicVerb = 11;

        public List<(int noun, int verb)> ExecutionInputs { get; set; }

        public TestCommand()
        {
            ExecutionInputs = new List<(int noun, int verb)>();
        }

        public override void Execute(Dictionary<string, object> data)
        {
            var prg = (int[])data[Prg1202NounVerbFinder.ProgramKey];
            (int noun, int verb) inputs = (prg[1], prg[2]);
            ExecutionInputs.Add(inputs);

            if (inputs.noun == MagicNoun && inputs.verb == MagicVerb)
            {
                prg[0] = MagicNumber;
            }
        }
    }
}