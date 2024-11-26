using TechSpecChecking.Text.Analyzers.TextAnalyzers;

namespace TechSpecChecking.Text.Testers
{
    public sealed class TextTester : Tester
    {
        private readonly string _text;

        public TextTester(string text) => _text = text;

        public override void Test()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("=== TEXT ANALYZERS ===");
            System.Console.WriteLine();

            var textAnalyzers = new ITextAnalyzer[]
            {
                new SectionsPresenceAnalyzer(),
                new SectionsOrderAnalyzer(),
            };

            foreach (var analyzer in textAnalyzers)
            {
                var result = analyzer.Analyze(_text, out string textAnalyzerError);
                PrintAnalyzerResult(analyzer, result, textAnalyzerError);
            }
        }
    }
}