using TechSpecChecking.Text.Analisators.TextAnalisators;

namespace TechSpecChecking.Text.Testers
{
    public sealed class TextTester : Tester
    {
        private readonly string _text;

        public TextTester(string text) => _text = text;

        public override void Test()
        {
            System.Console.WriteLine("=== TEXT ANALISATORS ===");
            System.Console.WriteLine();

            var textAnalisators = new ITextAnalisator[]
            {
                new SectionsPresenceAnalisator(),
            };

            foreach (var analisator in textAnalisators)
            {
                var result = analisator.Analyze(_text, out string textAnalisatorError);
                PrintAnalisatorResult(analisator, result, textAnalisatorError);
            }

            System.Console.WriteLine();
        }
    }
}