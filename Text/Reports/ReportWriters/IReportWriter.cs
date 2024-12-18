namespace TechSpecChecking.Text.Reports.ReportWriters
{
    public interface IReportWriter
    {
        void Write(IEnumerable<string> reportLines);
    }
}