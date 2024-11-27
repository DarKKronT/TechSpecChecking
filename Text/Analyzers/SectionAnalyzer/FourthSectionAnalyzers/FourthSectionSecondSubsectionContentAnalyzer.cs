using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FourthSectionAnalyzers
{
    public sealed class FourthSectionSecondSubsectionContentAnalyzer : ISectionAnalyzer
    {
        private const string FirstKeyWord = "Операційна систма";

        public string Name => "Fourth section second subsection content analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;
            
            if (section.Text.ToLower().Contains(FirstKeyWord.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain key word {FirstKeyWord}.";
                return false;
            }
            
            return true;
        }
    }
}