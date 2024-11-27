using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FourthSectionAnalyzers
{
    public sealed class FourthSectionSubsectionPresenceAnalyzer : ISectionAnalyzer
    {
        private const string FirstSubsectionTitle = "Функціональні вимоги";
        private const string SecondSubsectionTitle = "Вимоги до програмного забезпечення";
        private const string ThirdSubsectionTitle = "Вимоги до апаратної частини";

        public string Name => "Fourth section subsection presence analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;
            var lowerSectionText = section.Text.ToLower();
            
            if (lowerSectionText.ToLower().Contains(FirstSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsection title {FirstSubsectionTitle}.";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(SecondSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsection title {SecondSubsectionTitle}.";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(ThirdSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsection title {ThirdSubsectionTitle}.";
                return false;
            }            

            return true;
        }
    }
}