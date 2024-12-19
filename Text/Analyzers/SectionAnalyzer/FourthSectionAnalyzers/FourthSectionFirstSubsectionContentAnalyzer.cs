using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FourthSectionAnalyzers
{
    public sealed class FourthSectionFirstSubsectionContentAnalyzer : ISectionAnalyzer
    {
        private const string FirstKeyWord = "Інтерфейс користувача";
        private const string SecondKeyWord = "Користувацький інтерфейс";

        public string Name => "Fourth section first subsection content analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;
            var lowerSectionText = section.Text.ToLower();
            
            if (lowerSectionText.ToLower().Contains(FirstKeyWord.ToLower()) == false &&
                lowerSectionText.ToLower().Contains(SecondKeyWord.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain subsubsection title {FirstKeyWord} or {SecondKeyWord}.";
                return false;
            }  
            
            return true;
        }
    }
}