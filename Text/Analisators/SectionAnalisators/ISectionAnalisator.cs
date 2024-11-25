using Files.Sections;

namespace TechSpecChecking.Text.Analisators.SectionAnalisators
{
    public interface ISectionAnalisator : IAnalisator
    {
        bool Analyze(ISection section, out string error);
    }
}