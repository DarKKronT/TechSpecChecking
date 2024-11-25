namespace TechSpecChecking.Text.Analisators
{
    public interface IAnalisator
    {
        bool Analyze(string text, out string error);
    }
}