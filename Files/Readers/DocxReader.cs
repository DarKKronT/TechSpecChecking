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
                _fileText = string.Join("\n", body.Elements<Paragraph>().Select(p => p.InnerText));
            }
        }
    }
}