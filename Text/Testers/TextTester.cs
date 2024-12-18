using TechSpecChecking.Text.Analyzers.TextAnalyzers;

namespace TechSpecChecking.Text.Testers
{
    public sealed class TextTester : ITester
    {
        private readonly string _text;

        public TextTester(string text) => _text = text;

        public (IEnumerable<string> analyzerNames, IEnumerable<bool> results, IEnumerable<string> errors) Test()
        {
            var textAnalyzers = new ITextAnalyzer[]
            {
                new SectionsPresenceAnalyzer(),
                new SectionsOrderAnalyzer(),
            };

            var analyzerNames = new List<string>();
            var results = new List<bool>();
            var errors = new List<string>();

            foreach (var analyzer in textAnalyzers)
            {
                var result = analyzer.Analyze(_text, out string textAnalyzerError);
                
                analyzerNames.Add(analyzer.Name);
                results.Add(result);
                errors.Add(textAnalyzerError);
            }

            return (analyzerNames, results, errors);
        }
    }
}