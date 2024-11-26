using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.TextAnalyzers
{
    public sealed class SectionsPresenceAnalyzer : ITextAnalyzer
    {
        public string Name => "Section presence analyzer";

        public bool Analyze(string text, out string error)
        {
            error = string.Empty;
            text = text.ToLower();

            foreach (var sectionTitle in RequiredSections.MainSections)
            {
                if (text.Contains(sectionTitle.ToLower()) == false)
                {
                    error = $"Text does not contain section title {sectionTitle}";
                    return false;
                }
            }

            return true;
        }
    }
}