using TechSpecChecking.Text.Analyzers;

namespace TechSpecChecking.Text.ReportCreators
{
    public interface IReportCreator
    {
        string Create(IEnumerable<string> analyzerNames, IEnumerable<bool> results, IEnumerable<string> errors);
    }
}