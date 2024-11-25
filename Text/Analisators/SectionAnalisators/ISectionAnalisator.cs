using Files.Sections;

namespace TechSpecChecking.Text.Analisators.SectionAnalisators
{
    public interface ISectionAnalisator
    {
        bool Analyze(ISection section, out string error);
    }
}