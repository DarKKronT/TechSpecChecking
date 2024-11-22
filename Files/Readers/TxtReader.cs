using System.Text;

namespace TechSpecChecking.Files.Readers
{
    public sealed class TxtReader : IReader
    {
        private readonly string _filePath;
        private StringBuilder _fileText = new StringBuilder();

        public TxtReader(string filePath) => _filePath = filePath;

        public string FileText => _fileText.ToString();

        public void ReadFile()
        {
            System.Console.WriteLine("Reading txt...");

            using (var reader = new StreamReader(_filePath))
            {
                string line;
                
                while ((line = reader.ReadLine()) != null)
                    _fileText.Append(line + "\n");
            }
        }
    }
}