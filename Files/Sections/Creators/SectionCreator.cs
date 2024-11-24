using System.Text;

namespace Files.Sections.Creators
{
    public sealed class SectionCreator
    {
        private readonly string[] _requiredSections =
        {
            RequiredSections.FirstSectionTitle,
            RequiredSections.SecondSectionTitle,
            RequiredSections.ThirdSectionTitle,
            RequiredSections.FourthSectionTitle,
            RequiredSections.FifthSectionTitle,
            RequiredSections.SixthSectionTitle
        };

        public IEnumerable<ISection> GetSections(string text)
        {
            if (_requiredSections.Length == 0)
            {
                System.Console.WriteLine("There are no required sections.");
                return new List<ISection>();
            }

            var sections = new List<ISection>();
            var textToChange = new StringBuilder(text.ToLower()).Remove(0, text.ToLower().IndexOf(_requiredSections[0].ToLower()));

            foreach (var section in _requiredSections)
            {

            }

            return sections;
        }
    }
}