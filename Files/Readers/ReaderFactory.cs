namespace TechSpecChecking.Files.Readers
{
    public sealed class ReaderFactory
    {
        private readonly string _filePath;

        private const string TxtKey = ".txt";
        private const string DocxKey = ".docx";
        private const string PdfKey = ".pdf";

        private const string SeparatorKey = "\\";
        private const char ExtensionKey = '.';

        public ReaderFactory(string filePath) => _filePath = filePath;

        private string GetExtension()
        {
            var fileName = _filePath.Split(SeparatorKey)[^1];
            var extensionKeyIndex = fileName.ToLower().IndexOf(ExtensionKey);
            
            return fileName[extensionKeyIndex..];
        }

        public IReader GetReader()
        {
            var fileExtension = GetExtension();

            return fileExtension switch
            {
                TxtKey => new TxtReader(_filePath),
                DocxKey => new DocxReader(_filePath),
                PdfKey => new PdfReader(_filePath),
                _ => throw new NotSupportedException($"Unsupported file extension: {fileExtension}")
            };
        }
    }
}