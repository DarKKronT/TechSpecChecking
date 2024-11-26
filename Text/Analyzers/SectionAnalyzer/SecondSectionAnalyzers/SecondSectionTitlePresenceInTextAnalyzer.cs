using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.SecondSectionAnalyzers
{
    public sealed class SecondSectionTitlePresenceInTextAnalyzer : ISectionAnalyzer
    {
        private const string TitlePresenceInTextName = "Підставою для розроблення";

        public string Name => "Second section title presence in text analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;

            if (section.Text.ToLower().Contains(TitlePresenceInTextName.ToLower()) == false)
            {
                error = $"{RequiredSections.SecondSectionTitle} does not contain {TitlePresenceInTextName} in text.";
                return false;
            }

            return true;
        }
    }
}