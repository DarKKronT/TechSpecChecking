namespace Files.Sections
{
    public sealed class SimpleSection : ISection
    {
        private readonly string _title;
        private readonly string _text;

        public SimpleSection(string title, string text)
        {
            _title = title;
            _text = text;
        }

        public string Title => _title;
        public string Text => _text;
    }
}