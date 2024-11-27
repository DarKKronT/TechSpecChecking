using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FourthSectionAnalyzers
{
    public sealed class FourthSectionSubsubsectionPresenceAnalyzer : ISectionAnalyzer
    {
        private const string FirstSubsubsectionTitle = "Загальний опис";
        private const string SecondSubsubsectionTitle = "Функціональні вимоги";
        private const string ThirdSubsubsectionTitle = "Інтерфейс користувача";
        private const string FourthSubsubsectionTitle = "Нефункціональні вимоги";

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

            if (lowerSectionText.ToLower().Contains(ThirdSubsubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {ThirdSubsubsectionTitle}.";
                return false;
            }     

            if (lowerSectionText.ToLower().Contains(FourthSubsubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {FourthSubsubsectionTitle}.";
                return false;
            }         

            return true;
        }
    }
}