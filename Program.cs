using System.Text;
using TechSpecChecking.Files.Readers;
using System.Text.RegularExpressions;
using Files.Sections;
using Files.Sections.Creators;
using TechSpecChecking.Text.Analisators.TextAnalisators;
using TechSpecChecking.Text.Analisators.SectionAnalisators;
using TechSpecChecking.Text.Analisators.SectionAnalisators.FirstSectionAnalisators;
using TechSpecChecking.Text.Analisators;
using TechSpecChecking.Text.Analisators.SectionAnalisators.SecondSectionAnalisators;

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
            var textAfterContent = contentCreator.GetTextAfterContent(text);

            // System.Console.WriteLine(content.Title);
            // System.Console.WriteLine(content.Text);
            //System.Console.WriteLine(contentCreator.GetTextAfterContent(text));



            var sectionCreator = new SectionCreator();
            var sections = sectionCreator.GetSections(textAfterContent);

            // foreach (var section in sections)
            // {
            //     System.Console.WriteLine(section.Title);
            //     System.Console.WriteLine("=========================");
            //     System.Console.WriteLine(section.Text);
            //     System.Console.WriteLine("=========================");
            //     System.Console.WriteLine("=========================");
            //     System.Console.WriteLine("=========================");
            // }

            /*
            text

            content
            sections
            */

            var textAnalisators = new ITextAnalisator[]
            {
                new SectionsPresenceAnalisator(),
            };

            foreach (var analisator in textAnalisators)
            {
                var result = analisator.Analyze(text, out string textAnalisatorError);
                PrintAnalisatorResult(analisator, result, textAnalisatorError);
            }



            var firstSectionSubsectionPresenceAnalisator = new FirstSectionSubsectionPresenceAnalisator();
            var firstSectionSubsectionPresenceAnalisatorResult = firstSectionSubsectionPresenceAnalisator.Analyze(sections.ToArray()[0], out string sectionAnalisatorError1);
            PrintAnalisatorResult(firstSectionSubsectionPresenceAnalisator, firstSectionSubsectionPresenceAnalisatorResult, sectionAnalisatorError1);

            var secondSectionTitlePresenceInTextAnalisator = new SecondSectionTitlePresenceInTextAnalisator();
            var secondSectionTitlePresenceInTextAnalisatorResult = secondSectionTitlePresenceInTextAnalisator.Analyze(sections.ToArray()[1], out string sectionAnalisatorError2);
            PrintAnalisatorResult(secondSectionTitlePresenceInTextAnalisator, secondSectionTitlePresenceInTextAnalisatorResult, sectionAnalisatorError2);

            /*
            https://habr.com/ru/articles/341148/
            https://ru.wikipedia.org/wiki/%D0%A0%D0%B0%D1%81%D1%81%D1%82%D0%BE%D1%8F%D0%BD%D0%B8%D0%B5_%D0%9B%D0%B5%D0%B2%D0%B5%D0%BD%D1%88%D1%82%D0%B5%D0%B9%D0%BD%D0%B0
            */
        }

        private static void PrintAnalisatorResult(IAnalisator analisator, bool result, string error)
        {
            if (result == false)
            {
                System.Console.WriteLine($"{analisator.Name} has finished its work unsuccessfully with error:");
                System.Console.WriteLine(error);
                System.Console.WriteLine();

                return;
            }

            System.Console.WriteLine($"{analisator.Name} has finished its work successfully.");
            System.Console.WriteLine();
        }
    }
}