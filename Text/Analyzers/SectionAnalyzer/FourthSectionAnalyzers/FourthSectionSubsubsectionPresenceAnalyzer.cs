using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FourthSectionAnalyzers
{
    public sealed class FourthSectionSubsubsectionPresenceAnalyzer : ISectionAnalyzer
    {
        private const string FirstSubsectionTitle = "Загальний опис";
        private const string SecondSubsectionTitle = "Функціональні вимоги";
        private const string ThirdSubsectionTitle = "Інтерфейс користувача";
        private const string FourthSubsectionTitle = "Нефункціональні вимоги";

        public string Name => "Fourth section subsubsection presence analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;
            if (section.Text.ToLower().Contains(FirstSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {FirstSubsectionTitle}.";
                return false;
            }

            if (section.Text.ToLower().Contains(SecondSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {SecondSubsectionTitle}.";
                return false;
            }

            if (section.Text.ToLower().Contains(ThirdSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {ThirdSubsectionTitle}.";
                return false;
            }     

            if (section.Text.ToLower().Contains(FourthSubsectionTitle.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {FourthSubsectionTitle}.";
                return false;
            }         

            return true;
        }
    }
}