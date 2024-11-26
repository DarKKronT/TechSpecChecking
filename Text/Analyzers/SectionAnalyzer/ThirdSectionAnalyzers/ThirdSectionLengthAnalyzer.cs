using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.ThirdSectionAnalyzers
{
    public sealed class ThirdSectionLengthAnalyzer : ISectionAnalyzer
    {
        private const byte MinSectionLength = 5;

        public string Name => "Third section length analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;

            if (section.Text.Length < MinSectionLength)
            {
                error = $"{RequiredSections.ThirdSectionTitle} is empty.";
                return false;
            }

            return true;
        }
    }
}