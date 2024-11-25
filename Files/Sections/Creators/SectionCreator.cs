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

        public IEnumerable<ISection> GetSections(string textAfterContent)
        {
            if (_requiredSections.Length == 0)
            {
                System.Console.WriteLine("There are no required sections.");
                return new List<ISection>();
            }

            var sections = new List<ISection>();            
            var lastIndex = _requiredSections.Length - 1;

            textAfterContent = textAfterContent.ToLower();

            for (var i = 0; i <= lastIndex; i++)
            {
                if (i == lastIndex)
                {
                    var index = textAfterContent.IndexOf(_requiredSections[lastIndex].ToLower());

                    var lastTitle = _requiredSections[i].ToLower();
                    var lastText = textAfterContent.Substring(index).Replace(_requiredSections[lastIndex].ToLower(), string.Empty);;

                    sections.Add(new SimpleSection(lastTitle.Trim(), lastText.Trim()));                    
                    break;
                }

                var startIndex = textAfterContent.IndexOf(_requiredSections[i].ToLower());
                var endIndex = textAfterContent.IndexOf(_requiredSections[i + 1].ToLower());

                if (startIndex == -1)
                {
                    System.Console.WriteLine($"Text does not contain required section {_requiredSections[i]}");
                    break;
                }

                if (endIndex == -1)
                {
                    System.Console.WriteLine($"Text does not contain required section {_requiredSections[i + 1]}");
                    break;
                }

                var title = _requiredSections[i].ToLower();
                var text = textAfterContent.Substring(startIndex, endIndex - startIndex).Replace(_requiredSections[i].ToLower(), string.Empty);

                sections.Add(new SimpleSection(title.Trim(), text.Trim()));
            }

            return sections;
        }
    }
}