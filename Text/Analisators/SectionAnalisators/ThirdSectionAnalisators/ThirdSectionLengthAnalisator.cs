using Files.Sections;

namespace TechSpecChecking.Text.Analisators.SectionAnalisators.ThirdSectionAnalisators
{
    public sealed class ThirdSectionLengthAnalisator : ISectionAnalisator
    {
        private const byte MinSectionLength = 5;

        public string Name => "Third section length analisator";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;

            if (section.Text.Length < MinSectionLength)
            {
                error = $"{RequiredSections.ThirdSectionTitle} is empty.";
                return false;
            }

            return true;
        }
    }
}