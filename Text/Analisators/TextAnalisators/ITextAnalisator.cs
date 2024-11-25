namespace TechSpecChecking.Text.Analisators.TextAnalisators
{
    public interface ITextAnalisator
    {
        bool Analyze(string text, out string error);
    }
}