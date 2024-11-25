using System.Text;
using TechSpecChecking.Files.Readers;
using System.Text.RegularExpressions;
using Files.Sections;
using Files.Sections.Creators;
using TechSpecChecking.Text.Analisators.TextAnalisators;
using TechSpecChecking.Text.Analisators.SectionAnalisators;

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
                new SectionsPresenceAnaliator()
            };

            foreach (var analisator in textAnalisators)
            {
                if (analisator.Analyze(text, out string error) == false)
                {
                    System.Console.WriteLine($"{analisator.Name} has finished its work unsuccessfully with error:");
                    System.Console.WriteLine(error);
                }
                
                System.Console.WriteLine($"{analisator.Name} has finished its work successfully.");
            }

            var sectionAnalisators = new ISectionAnalisator[]
            {

            };

            foreach (var analisator in sectionAnalisators)
            {
                
            }
        }
    }
}