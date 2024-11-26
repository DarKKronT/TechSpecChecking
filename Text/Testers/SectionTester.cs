using Files.Sections;
using TechSpecChecking.Text.Analisators.SectionAnalisators;
using TechSpecChecking.Text.Analisators.SectionAnalisators.FirstSectionAnalisators;
using TechSpecChecking.Text.Analisators.SectionAnalisators.SecondSectionAnalisators;
using TechSpecChecking.Text.Analisators.SectionAnalisators.ThirdSectionAnalisators;
using TechSpecChecking.Text.Analisators.SectionAnalisators.FourthSectionAnalisators;

namespace TechSpecChecking.Text.Testers
{
    public sealed class SectionTester : Tester
    {
        private readonly ISection[] _sections;
        private readonly byte[] Indexes =
        {
            FirstSectionIndex,
            SecondSectionIndex,
            ThirdSectionIndex,
            FourthSectionIndex,
            FifthSectionIndex,
            SixthSectionIndex
        };

        private const byte FirstSectionIndex = 0;
        private const byte SecondSectionIndex = 1;
        private const byte ThirdSectionIndex = 2;
        private const byte FourthSectionIndex = 3;
        private const byte FifthSectionIndex = 4;
        private const byte SixthSectionIndex = 5;

        public SectionTester(ISection[] sections) => _sections = sections;

        public override void Test()
        {
            if (RequiredSections.MainSections.Length != Indexes.Length)
                throw new InvalidOperationException("Length of RequiredSections.MainSections does not match Indexes length.");

            if (_sections.Length != Indexes.Length)
                throw new InvalidOperationException("Number of sections does not match the number of indexes.");

            var analisators = new List<(ISection section, ISectionAnalisator analisator)>
            {
                (_sections[FirstSectionIndex], new FirstSectionSubsectionPresenceAnalisator()),
                (_sections[FirstSectionIndex], new FirstSectionLengthAnalisator()),

                (_sections[SecondSectionIndex], new SecondSectionTitlePresenceInTextAnalisator()),
                (_sections[SecondSectionIndex], new SecondSectionLengthAnalisator()),

                (_sections[ThirdSectionIndex], new ThirdSectionLengthAnalisator()),

                (_sections[FourthSectionIndex], new FourthSectionSubsectionPresenceAnalisator()),
            };

            System.Console.WriteLine();
            System.Console.WriteLine("=== SECTION ANALISATORS ===");
            System.Console.WriteLine();

            foreach (var (section, analisator) in analisators)
            {
                var result = analisator.Analyze(section, out string error);
                PrintAnalisatorResult(analisator, result, error);
            }            
        }
    }
}