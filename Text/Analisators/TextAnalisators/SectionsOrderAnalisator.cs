using Files.Sections;

namespace TechSpecChecking.Text.Analisators.TextAnalisators
{
    public sealed class SectionsOrderAnalisator : ITextAnalisator
    {
        public string Name => "Sections order analisator";

        public bool Analyze(string text, out string error)
        {
            error = string.Empty;
            text = text.ToLower();

            var sectionIndexes = RequiredSections.MainSections.Select(title => text.IndexOf(title.ToLower())).ToArray();

            if (!sectionIndexes.SequenceEqual(sectionIndexes.Order()))
            {
                var unorderedSections = sectionIndexes
                    .Select((index, i) => new { Index = index, Title = RequiredSections.MainSections[i] })
                    .OrderBy(x => x.Index)
                    .Where((x, i) => sectionIndexes[i] != x.Index)
                    .Select(x => $"\"{x.Title}\"");

                error = $"Sections are not in the correct order: {string.Join(", ", unorderedSections)}.";
                return false;
            }

            return true;
        }
    }
}