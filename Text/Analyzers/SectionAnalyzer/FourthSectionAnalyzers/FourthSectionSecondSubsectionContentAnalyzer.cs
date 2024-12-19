using Files.Sections;

namespace TechSpecChecking.Text.Analyzers.SectionAnalyzers.FourthSectionAnalyzers
{
    public sealed class FourthSectionSecondSubsectionContentAnalyzer : ISectionAnalyzer
    {
        private const string FirstKeyWord = "Продуктивність";
        private const string SecondKeyWord = "Вимоги до програмного забезпечення";
        private const string ThirdKeyWord = "Вимоги до апаратної частини";

        private const string FirstDeviceType = "Комп'ютер";
        private const string SecondDeviceType = "Ноутбук";
        private const string ThirdDeviceType = "Лептоп";
        private const string FourthDeviceType = "Планшет";
        private const string FifthDeviceType = "Телефон";

        private readonly string[] _devices =
        {
            FirstDeviceType,
            SecondDeviceType,
            ThirdDeviceType,
            FourthDeviceType,
            FifthDeviceType
        };

        private const string FirstComputerComponent = "Процесор";
        private const string SecondComputerComponent = "Оперативн";

        public string Name => "Fourth section second subsection content analyzer";

        public bool Analyze(ISection section, out string error)
        {
            error = string.Empty;
            var lowerSectionText = section.Text.ToLower();
            
            if (lowerSectionText.ToLower().Contains(FirstKeyWord.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain key word {FirstKeyWord}.";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(SecondKeyWord.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain key word {SecondKeyWord}.";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(ThirdKeyWord.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain key word {ThirdKeyWord}.";
                return false;
            }

            if (_devices.Any(device => lowerSectionText.Contains(device.ToLower())) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain any required device types ({string.Join(", ", _devices)}).";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(FirstComputerComponent.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain information about {FirstComputerComponent}.";
                return false;
            }

            if (lowerSectionText.ToLower().Contains(SecondComputerComponent.ToLower()) == false)
            {
                error = $"{RequiredSections.FourthSectionTitle} does not contain information about {SecondComputerComponent}.";
                return false;
            }
            
            return true;
        }
    }
}