using Files.Sections;

namespace TechSpecChecking.Text.Analisators
{
    public interface ISectionAnalisator
    {
        bool Analyze(ISection section, out string error);
    }
}