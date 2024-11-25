namespace TechSpecChecking.Text.Analisators.TextAnalisators
{
    public interface ITextAnalisator : IAnalisator
    {
        bool Analyze(string text, out string error);
    }
}