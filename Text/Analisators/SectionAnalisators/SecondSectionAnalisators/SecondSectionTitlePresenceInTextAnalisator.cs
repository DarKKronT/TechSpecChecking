using Files.Sections;

namespace TechSpecChecking.Text.Analisators.SectionAnalisators.SecondSectionAnalisators
{
    public sealed class SecondSectionTitlePresenceInTextAnalisator : ISectionAnalisator
    {
        private const string TitlePresenceInTextName = "Підставою для розроблення";

        public string Name => "Second section title presence in text";

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