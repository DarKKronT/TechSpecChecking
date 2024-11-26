using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers
{
    public interface ISectionAnalyzer : IAnalyzer
    {
        bool Analyze(ISection section, out string error);
    }
}