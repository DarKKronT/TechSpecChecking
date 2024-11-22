using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace TechSpecChecking.Files.Readers
{
    public sealed class PdfReader : IReader
    {
        private readonly string _filePath;
        private StringBuilder _fileText = new StringBuilder();

        public PdfReader(string filePath) => _filePath = filePath;

        public string FileText => _fileText.ToString();

        public void ReadFile()
        {
            using (var reader = new iText.Kernel.Pdf.PdfReader(_filePath))
            {
                using (var pdfDocument = new PdfDocument(reader))
                {
                    for (var i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
                    {
                        var pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(i));
                        _fileText.AppendLine(pageText);
                    }
                }
            }            
        }
    }
}