using System.Text;
using TechSpecChecking.Files.Readers;
using Files.Sections.Creators;
using TechSpecChecking.Text.Testers;
using TechSpecChecking.Text.Reports.ReportCreators;
using TechSpecChecking.Text.Reports.ReportWriters;

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

            var filePath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\TestDocs\\TechnicalSpecification.docx";

            System.Console.WriteLine("Welcome to TechSpecChecking!");            
            var directories = filePath.Split("\\");
            var fileName = directories[directories.Length - 1];

            System.Console.WriteLine($"The file named {fileName} will now be processed.");
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            var reportPath = "D:\\KPI\\3\\sem 1\\COURSEWORK\\Docs\\Reports";
            var reportName = "Report";

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
            var textReportLines = defaultReportCreator.Create(textAnalyzers, textResults, textErrors);
            var sectionReportLines = defaultReportCreator.Create(sectionAnalyzers, sectionResults, sectionErrors);

            var report = new List<string>();

            report.AddRange(textReportLines);
            report.AddRange(sectionReportLines);
            
            new TxtReportWriter(reportPath, reportName).Write(report);
            new WordReportWriter(reportPath, reportName).Write(report);

            System.Console.WriteLine("- Analysis of the technical specification;");
            System.Console.WriteLine("- Generation of reports;");
            System.Console.WriteLine();
            System.Console.WriteLine("Was completed successfully.");
        }
    }
}