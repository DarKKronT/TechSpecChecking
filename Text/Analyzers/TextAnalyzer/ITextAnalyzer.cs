namespace TechSpecChecking.Text.Analyzers.TextAnalyzers
{
    public interface ITextAnalyzer : IAnalyzer
    {
        bool Analyze(string text, out string error);
    }
}