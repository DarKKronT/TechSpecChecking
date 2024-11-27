using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FirstSectionAnalyzers
{
    public sealed class FirstSectionLengthAnalyzer : ISectionAnalyzer
    {
        private const byte MinSectionLength = 5;

        public string Name => "First section length analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;

            if (section.Text.Length < MinSectionLength)
            {
                error = $"{RequiredSections.FirstSectionTitle} is empty.";
                return false;
            }

            return true;
        }
    }
}