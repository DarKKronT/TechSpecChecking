using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FirstSectionAnalyzers
{
    public sealed class FirstSectionSubsectionPresenceAnalyzer : ISectionAnalyzer
    {
        private const string FirstSubsectionTitle = "Найменування";
        private const string SecondSubsectionTitle = "Галузь застосування";

        public string Name => "First section subsection presence analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;
            
            if (section.Text.ToLower().Contains(FirstSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FirstSectionTitle} does not contain subsection title {FirstSubsectionTitle}.";
                return false;
            }

            if (section.Text.ToLower().Contains(SecondSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FirstSectionTitle} does not contain subsection title {SecondSubsectionTitle}.";
                return false;
            }

            return true;
        }
    }
}