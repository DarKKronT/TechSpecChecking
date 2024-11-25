using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace TechSpecChecking.Files.Readers
{
    public sealed class DocxReader : IReader
    {
        private readonly string _filePath;
        private string _fileText;

        public DocxReader(string filePath) => _filePath = filePath;

        public string FileText => _fileText;

        public void ReadFile()
        {
            using (var wordDoc = WordprocessingDocument.Open(_filePath, false))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;

                var paragraphsText = body.Elements<Paragraph>().Select(p => p.InnerText);

                var tablesText = body.Elements<Table>()
                                     .SelectMany(table =>
                                         table.Elements<TableRow>().Select(row =>
                                             string.Join("\t", row.Elements<TableCell>().Select(cell => cell.InnerText))
                                         ));

                _fileText = string.Join("\n", paragraphsText.Concat(tablesText));
            }
        }
    }
}