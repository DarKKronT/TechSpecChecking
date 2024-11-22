namespace TechSpecChecking.Files.Readers
{
    public sealed class PdfReader : IReader
    {
        private readonly string _filePath;

        public PdfReader(string filePath) => _filePath = filePath;

        public string FileText => throw new NotImplementedException();

        public void ReadFile()
        {
            System.Console.WriteLine("Reading pdf...");
        }
    }
}