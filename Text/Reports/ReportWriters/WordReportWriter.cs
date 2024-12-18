using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace TechSpecChecking.Text.Reports.ReportWriters
{
    public sealed class WordReportWriter : IReportWriter
    {
        private readonly string _filePath;
        private readonly string _fileName;

        private const string RunFontsAscii = "Times New Roman";
        private const string FontSizeVal = "28";

        private const string DocxExtension = ".docx";

        public WordReportWriter(string filePath, string fileName)
        {
            _filePath = filePath;
            _fileName = fileName;
        }

        public void Write(IEnumerable<string> reportLines)
        {
            var path = _filePath + "\\" + _fileName + DocxExtension;

            using (var wordDocument = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document))
            {
                var mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                var body = mainPart.Document.AppendChild(new Body());

                var headerRun = new Run(
                    new RunProperties(new RunFonts() { Ascii = RunFontsAscii }, new FontSize() { Val = FontSizeVal }),
                    new DocumentFormat.OpenXml.Wordprocessing.Text("REPORT"));
                var headerParagraph = new Paragraph(headerRun);

                var separatorRun = new Run(
                    new RunProperties(new RunFonts() { Ascii = RunFontsAscii }, new FontSize() { Val = FontSizeVal }),
                    new DocumentFormat.OpenXml.Wordprocessing.Text("================"));
                var separatorParagraph = new Paragraph(separatorRun);

                body.Append(headerParagraph);
                body.Append(separatorParagraph);

                foreach (var line in reportLines)
                {
                    var run = new Run(
                        new RunProperties(new RunFonts() { Ascii = RunFontsAscii }, new FontSize() { Val = FontSizeVal }),
                        new DocumentFormat.OpenXml.Wordprocessing.Text(line));

                    var paragraph = new Paragraph(run);
                    body.Append(paragraph);
                }

                mainPart.Document.Save();
            }
        }
    }
}
