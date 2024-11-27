using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FourthSectionAnalyzers
{
    public sealed class FourthSectionThirdSubsectionContentAnalyzer : ISectionAnalyzer
    {
        private const string FirstDeviceType = "Комп'ютер";
        private const string SecondDeviceType = "Ноутбук";
        private const string ThirdDeviceType = "Лептоп";
        private const string FourthDeviceType = "Планшет";
        private const string FifthDeviceType = "Телефон";

        private const string FirstKeyWord = "Процесор";
        private const string SecondKeyWord = "Оперативн";

        private readonly string[] _devices =
        {
            FirstDeviceType,
            SecondDeviceType,
            ThirdDeviceType,
            FourthDeviceType,
            FifthDeviceType
        };

        public string Name => "Fourth section third subsection content analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;
            var lowerSectionText = section.Text.ToLower();
            
            if (_devices.Any(device => lowerSectionText.Contains(device.ToLower())) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain any required device types ({string.Join(", ", _devices)}).";
                return false;
            }

            if (lowerSectionText.Contains(FirstKeyWord.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain required information about processor.";
                return false;
            }

            if (lowerSectionText.Contains(SecondKeyWord.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain required information about RAM.";
                return false;
            }
            
            return true;
        }
    }
}