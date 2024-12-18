namespace TechSpecChecking.Text.Reports.ReportCreators
{
    public interface IReportCreator
    {
        IEnumerable<string> Create(IEnumerable<string> analyzerNames, IEnumerable<bool> results, IEnumerable<string> errors);
    }
}