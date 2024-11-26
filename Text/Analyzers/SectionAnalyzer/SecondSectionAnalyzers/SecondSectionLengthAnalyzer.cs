using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.SecondSectionAnalyzers
{
    public sealed class SecondSectionLengthAnalyzer : ISectionAnalyzer
    {
        private const byte MinSectionLength = 5;

        public string Name => "Second section length analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;

            if (section.Text.Length < MinSectionLength)
            {
                error = $"{RequiredSections.SecondSectionTitle} is empty.";
                return false;
            }

            return true;
        }
    }
}