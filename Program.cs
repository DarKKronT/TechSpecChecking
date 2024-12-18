using System.Text;
using TechSpecChecking.Files.Readers;
using Files.Sections.Creators;
using TechSpecChecking.Text.Testers;
using TechSpecChecking.Text.Reports.ReportCreators;

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
            //var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\КП-21 Антонов Євгеній ТЗ на перевірку_removed.pdf";

            //var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\ТЗ шаблон for tests.docx";

            var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\КП-21_Антонов_Євгеній_Технічне_завдання.docx";



            var reportPath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\Report.txt";

            var readerFactory = new ReaderFactory(filePath);
            var reader = readerFactory.GetReader();

            reader.ReadFile();
            var text = reader.FileText;

            var contentCreator = new ContentCreator();
            var content = contentCreator.GetContent(text);
            var textAfterContent = contentCreator.GetTextAfterContent(text);

            var sectionCreator = new SectionCreator();
            var sections = sectionCreator.GetSections(textAfterContent);

            var textTesterResult = new TextTester(text).Test();
            var sectionTesterResult = new SectionTester(sections.ToArray()).Test();

            var (textAnalyzers, textResults, textErrors) = textTesterResult;
            var (sectionAnalyzers, sectionResults, sectionErrors) = sectionTesterResult;

            var defaultReportCreator = new DefaultReportCreator();
            System.Console.WriteLine(defaultReportCreator.Create(textAnalyzers, textResults, textErrors));
            System.Console.WriteLine(defaultReportCreator.Create(sectionAnalyzers, sectionResults, sectionErrors));
        }
    }
}