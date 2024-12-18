namespace TechSpecChecking.Text.Reports.ReportCreators
{
    public sealed class DefaultReportCreator : IReportCreator
    {
        public IEnumerable<string> Create(IEnumerable<string> analyzerNames, IEnumerable<bool> results, IEnumerable<string> errors)
        {
            var lengths = new int[]
            {
                analyzerNames.Count(),
                results.Count(),
                errors.Count()
            };

            if (lengths.Distinct().Count() != 1)
                 throw new ArgumentException("The lengths of the passed collections do not match.");
            
            var reportLines = new List<string>();        

            var analyzerNamesList = analyzerNames.ToList();
            var resultsList = results.ToList();
            var errorsList = errors.ToList();

            for (int i = 0; i < analyzerNamesList.Count; i++)
            {
                reportLines.Add($"- Analyzer: {analyzerNamesList[i].ToString()}");
                reportLines.Add($"- Result: {(resultsList[i] ? "Successful" : "Failed")}");
                reportLines.Add($"- Error: {errorsList[i]}");
                reportLines.Add("----------------");
            }

            return reportLines;
        }
    }
}