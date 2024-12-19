using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FourthSectionAnalyzers
{
    public sealed class FourthSectionSubsubsectionPresenceAnalyzer : ISectionAnalyzer
    {
        private const string FirstSubsubsectionTitle = "Функціональні вимоги";
        private const string SecondSubsubsectionTitle = "Нефункціональні вимоги";
        private const string ThirdFirstSubsubsectionTitle = "Інтерфейс користувача";
        private const string ThirdSecondSubsubsectionTitle = "Користувацький інтерфейс";

        public string Name => "Fourth section subsubsection presence analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;
            var lowerSectionText = section.Text.ToLower();
            
            if (lowerSectionText.ToLower().Contains(FirstSubsubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {FirstSubsubsectionTitle}.";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(SecondSubsubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {SecondSubsubsectionTitle}.";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(ThirdFirstSubsubsectionTitle.ToLower()) == false &&
                lowerSectionText.ToLower().Contains(ThirdSecondSubsubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {ThirdFirstSubsubsectionTitle} or {ThirdSecondSubsubsectionTitle}.";
                return false;
            }     

            return true;
        }
    }
}