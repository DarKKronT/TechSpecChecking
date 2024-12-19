using Files.Sections;
using TechSpecChecking.Text.Analyzers.SectionAnalyzers;
using TechSpecChecking.Text.Analyzers.SectionAnalyzers.FirstSectionAnalyzers;
using TechSpecChecking.Text.Analyzers.SectionAnalyzers.SecondSectionAnalyzers;
using TechSpecChecking.Text.Analyzers.SectionAnalyzers.ThirdSectionAnalyzers;
using TechSpecChecking.Text.Analyzers.SectionAnalyzers.FourthSectionAnalyzers;
using TechSpecChecking.Text.Analyzers.SectionAnalyzers.FifthSectionAnalyzers;
using TechSpecChecking.Text.Analyzers.SectionAnalyzers.SixthSectionAnalyzers;

namespace TechSpecChecking.Text.Testers
{
    public sealed class SectionTester : ITester
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

        public (IEnumerable<string> analyzerNames, IEnumerable<bool> results, IEnumerable<string> errors) Test()
        {
            if (RequiredSections.MainSections.Length != Indexes.Length)
                throw new InvalidOperationException("Length of RequiredSections.MainSections does not match Indexes length.");

            if (_sections.Length != Indexes.Length)
                throw new InvalidOperationException("Number of sections does not match the number of indexes.");

            var analyzers = new List<(ISection section, ISectionAnalyzer analyzer)>
            {
                (_sections[FirstSectionIndex], new FirstSectionSubsectionPresenceAnalyzer()),
                (_sections[FirstSectionIndex], new FirstSectionLengthAnalyzer()),

                (_sections[SecondSectionIndex], new SecondSectionTitlePresenceInTextAnalyzer()),
                (_sections[SecondSectionIndex], new SecondSectionLengthAnalyzer()),

                (_sections[ThirdSectionIndex], new ThirdSectionLengthAnalyzer()),

                (_sections[FourthSectionIndex], new FourthSectionSubsectionPresenceAnalyzer()),
                (_sections[FourthSectionIndex], new FourthSectionFirstSubsectionContentAnalyzer()),
                (_sections[FourthSectionIndex], new FourthSectionSecondSubsectionContentAnalyzer()),
                
                (_sections[FifthSectionIndex], new FifthSectionSubsectionPresenceAnalyzer()),
                (_sections[FifthSectionIndex], new FifthSectionLengthAnalyzer()),

                (_sections[SixthSectionIndex], new SixthSectionLengthAnalyzer())
            };

            var analyzerNames = new List<string>();
            var results = new List<bool>();
            var errors = new List<string>();            

            foreach (var (section, analyzer) in analyzers)
            {
                var result = analyzer.Analyze(section, out string error);
                
                analyzerNames.Add(analyzer.Name);
                results.Add(result);
                errors.Add(error);
            }

            return (analyzerNames, results, errors);        
        }
    }
}