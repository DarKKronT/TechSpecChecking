using System.Text;
using TechSpecChecking.Files.Readers;
using System.Text.RegularExpressions;
using Files.Sections;
using Files.Sections.Creators;

namespace TechSpecChecking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;

            //var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\КП-21 Антонов Євгеній ТЗ на перевірку.pdf";
            //var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\ТЗ шаблон.docx";
            var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\КП-21 Антонов Євгеній ТЗ на перевірку_removed.pdf";

            var readerFactory = new ReaderFactory(filePath);
            var reader = readerFactory.GetReader();

            reader.ReadFile();
            var text = reader.FileText;



            var contentCreator = new ContentCreator();
            var content = contentCreator.GetContent(text);
            // System.Console.WriteLine(content.Title);
            // System.Console.WriteLine(content.Text);

            //System.Console.WriteLine(contentCreator.GetTextAfterContent(text));



            var sectionCreator = new SectionCreator();
            var sections = sectionCreator.GetSections(text);
            //System.Console.WriteLine(text);






            // Перелік розділів, які повинні бути в технічному завданні
            string[] requiredSections =
            {
                RequiredSections.FirstSectionTitle,
                RequiredSections.SecondSectionTitle,
                RequiredSections.ThirdSectionTitle,
                RequiredSections.FourthSectionTitle,
                RequiredSections.FifthSectionTitle,
                RequiredSections.SixthSectionTitle
            };

            // Test1(text, requiredSections);
            // System.Console.WriteLine("====================");
            // Test2(text, requiredSections);
        }

        private static void Test1(string text, string[] requiredSections)
        {
            // Для кожного розділу перевіряємо наявність
            foreach (string section in requiredSections)
            {
                string pattern = $@"\b{Regex.Escape(section)}\b";  // Шукаємо точний збіг назви розділу
                bool found = Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase);
                Console.WriteLine(found ? $"{section} знайдено" : $"{section} не знайдено");
            }
        }

        private static void Test2(string text, string[] requiredSections)
        {
            foreach (string section in requiredSections)
            {
                // Шукаємо заголовок розділу
                string pattern = $@"\b{Regex.Escape(section)}\b";
                Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
                MatchCollection matchCollection = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
                
                if (match.Success)
                {
                    // Знаходимо текст після заголовка
                    int startIndex = match.Index + match.Length;
                    string sectionText = text.Substring(startIndex).Split('\n')[0];  // Перша строка після заголовка
                    
                    // Перевіряємо, чи текст не порожній
                    if (string.IsNullOrWhiteSpace(sectionText))
                    {
                        Console.WriteLine($"{section} заповнений неповністю або порожній.");
                    }
                    else
                    {
                        Console.WriteLine($"{section} заповнений.");
                    }
                }
                else
                {
                    Console.WriteLine($"{section} не знайдено.");
                }
            }
        }
    }
}