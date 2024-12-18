namespace TechSpecChecking.Text.Reports.ReportWriters
{
    public sealed class TxtReportWriter : IReportWriter
    {
        private readonly string _filePath;
        private readonly string _fileName;

        private const string TxtExtension = ".txt";

        public TxtReportWriter(string filePath, string fileName)
        {
            _filePath = filePath;
            _fileName = fileName;
        }

        public void Write(IEnumerable<string> reportLines)
        {
            var path = _filePath + "\\" + _fileName + TxtExtension;
            
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("REPORT");
                writer.WriteLine("================");

                foreach (var line in reportLines)
                    writer.WriteLine(line);
            }
        }
    }
}