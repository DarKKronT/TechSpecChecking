using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FifthSectionAnalyzers
{
    public sealed class FifthSectionSubsectionPresenceAnalyzer : ISectionAnalyzer
    {
        private const string FirstSubsectionTitle = "Пояснювальна записка";
        private const string SecondSubsectionTitle = "Керівництво користувача";
        private const string ThirdSubsectionTitle = "Графічний матеріал";

        public string Name => "Fifth section subsection presence analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;
            var lowerSectionText = section.Text.ToLower();
            
            if (lowerSectionText.ToLower().Contains(FirstSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FifthSectionTitle} does not contain subsection title {FirstSubsectionTitle}.";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(SecondSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FifthSectionTitle} does not contain subsection title {SecondSubsectionTitle}.";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(ThirdSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FifthSectionTitle} does not contain subsection title {ThirdSubsectionTitle}.";
                return false;
            }

            return true;
        }
    }
}