using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.SixthSectionAnalyzers
{
    public sealed class SixthSectionLengthAnalyzer : ISectionAnalyzer
    {
        private const byte MinSectionLength = 5;

        public string Name => "Sixth section length analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;

            if (section.Text.Length < MinSectionLength)
            {
                error = $"{RequiredSections.SixthSectionTitle} is empty.";
                return false;
            }

            return true;
        }
    }
}