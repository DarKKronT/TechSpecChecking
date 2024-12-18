namespace TechSpecChecking.Text.Reports.ReportCreators
{
    public sealed class DefaultReportCreator : IReportCreator
    {
        public string Create(IEnumerable<string> analyzerNames, IEnumerable<bool> results, IEnumerable<string> errors)
        {
            var lengths = new int[]
            {
                analyzerNames.Count(),
                results.Count(),
                errors.Count()
            };

            if (lengths.Distinct().Count() != 1)
                 throw new ArgumentException("The lengths of the passed collections do not match.");
            
            var report = new System.Text.StringBuilder();
            report.AppendLine("REPORT");
            report.AppendLine("================");

            var analyzerNamesList = analyzerNames.ToList();
            var resultsList = results.ToList();
            var errorsList = errors.ToList();

            for (int i = 0; i < analyzerNamesList.Count; i++)
            {
                report.AppendLine($"- Analyzer: {analyzerNamesList[i].ToString()}");
                report.AppendLine($"- Result: {(resultsList[i] ? "Successful" : "Failed")}");
                report.AppendLine($"- Error: {errorsList[i]}");
                report.AppendLine("----------------");
            }

            return report.ToString();
        }
    }
}