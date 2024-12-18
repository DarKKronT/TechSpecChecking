namespace TechSpecChecking.Text.Reports.ReportWriters
{
    public sealed class TxtReportWriter : IReportWriter
    {
        private readonly string _filePath;

        public TxtReportWriter(string filePath) => _filePath = filePath;

        public void Write(IEnumerable<string> reportLines)
        {
            using (var writer = new StreamWriter(_filePath))
            {
                writer.WriteLine("REPORT");
                writer.WriteLine("================");

                foreach (var line in reportLines)
                    writer.WriteLine(line);
            }
        }
    }
}