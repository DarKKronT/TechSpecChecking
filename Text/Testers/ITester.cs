namespace TechSpecChecking.Text.Testers
{
    public interface ITester
    {
        (IEnumerable<string> analyzerNames, IEnumerable<bool> results, IEnumerable<string> errors) Test();
    }
}