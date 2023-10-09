namespace TestResultsAnalyzer.Models
{
    /// <summary>
    /// Represents the result of an individual test case.
    /// </summary>
    public class TestCaseResult
    {
        public string TestCaseName { get; set; }
        public string Status { get; set; }
        public int ExecutionTime { get; set; }
        public DateTime Timestamp { get; set; }
        public string Module { get; set; }
        public string TesterName { get; set; }
    }

}
