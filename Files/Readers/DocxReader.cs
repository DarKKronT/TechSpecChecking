namespace TechSpecChecking.Files.Readers
{
    public sealed class DocxReader : IReader
    {
        private readonly string _filePath;

        public DocxReader(string filePath) => _filePath = filePath;

        public string FileText => throw new NotImplementedException();

        public void ReadFile()
        {
            System.Console.WriteLine("Reading docx...");
        }
    }
}