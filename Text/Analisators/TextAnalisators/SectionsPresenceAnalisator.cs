using Files.Sections;

namespace TechSpecChecking.Text.Analisators.TextAnalisators
{
    public sealed class SectionsPresenceAnalisator : ITextAnalisator
    {
        public string Name => "Section presence analisator";

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