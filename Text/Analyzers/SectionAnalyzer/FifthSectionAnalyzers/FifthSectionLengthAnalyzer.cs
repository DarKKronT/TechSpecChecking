using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FifthSectionAnalyzers
{
    public sealed class FifthSectionLengthAnalyzer : ISectionAnalyzer
    {
        private const byte MinSectionLength = 4;

        public string Name => "Fifth section length analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;

            if (section.Text.Length < MinSectionLength)
            {
                error = $"{RequiredSections.FifthSectionTitle} is empty.";
                return false;
            }

            return true;
        }
    }
}