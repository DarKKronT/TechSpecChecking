namespace TechSpecChecking.Files.Readers
{
    public interface IReader
    {
        string FileText { get; }

        void ReadFile();
    }
}