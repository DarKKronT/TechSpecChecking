using System.Text.RegularExpressions;

namespace Files.Sections.Creators
{
    public sealed class ContentCreator
    {
        private const byte MinTitleCount = 2;

        public ISection GetContent(string text)
        {
            text = text.ToLower();

            if (Regex.Matches(text, Regex.Escape(RequiredSections.FirstSectionTitle.ToLower())).Count < MinTitleCount)
            {
                System.Console.WriteLine($"{RequiredSections.FirstSectionTitle} is missing from the main text or table of contents.");
                return null;
            }
            
            var contentTitleIndex = text.IndexOf(RequiredSections.ContentSectionTitle.ToLower());

            var firstIndex = text.IndexOf(RequiredSections.FirstSectionTitle.ToLower());
            var contentEndIndex = text.IndexOf(RequiredSections.FirstSectionTitle.ToLower(), firstIndex + RequiredSections.FirstSectionTitle.Length);

            var contentText = text.Substring(contentTitleIndex, contentEndIndex - contentTitleIndex);
            var content = contentText.Replace(RequiredSections.ContentSectionTitle.ToLower(), string.Empty);

            return new SimpleSection(RequiredSections.ContentSectionTitle, content);
        }

        public string GetTextAfterContent(string text)
        {
            text = text.ToLower();

            if (Regex.Matches(text, Regex.Escape(RequiredSections.FirstSectionTitle.ToLower())).Count < MinTitleCount)
            {
                System.Console.WriteLine($"{RequiredSections.FirstSectionTitle} is missing from the main text or table of contents.");
                return null;
            }

            var firstIndex = text.IndexOf(RequiredSections.FirstSectionTitle.ToLower());
            var contentEndIndex = text.IndexOf(RequiredSections.FirstSectionTitle.ToLower(), firstIndex + RequiredSections.FirstSectionTitle.Length);

            return text.Substring(contentEndIndex);
        }
    }
}