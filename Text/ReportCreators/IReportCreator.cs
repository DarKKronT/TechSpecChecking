using TechSpecChecking.Text.Analyzers.SectionAnalyzers;

namespace TechSpecChecking.Text.ReportCreators
{
    public interface IReportCreator
    {
        string Create(IEnumerable<ISectionAnalyzer> sectionAnalyzers, IEnumerable<bool> results, IEnumerable<string> errors);
    }
}