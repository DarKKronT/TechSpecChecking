using Files.Sections;

namespace TechSpecChecking.Text.Analisators.SectionAnalisators.FirstSectionAnalisators
{
    public sealed class FirstSectionLengthAnalisator : ISectionAnalisator
    {
        private const byte MinSectionLength = 5;

        public string Name => "First section length analisator";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;

            if (section.Text.Length < MinSectionLength)
            {
                error = $"{RequiredSections.FirstSectionTitle} is empty.";
                return false;
            }

            return true;
        }
    }
}