using TestResultsAnalyzer.Models;

namespace TestResultsAnalyzer.Services
{
    public class MetricsService
    {
        public int TotalTestCases(TestResults testResults)
        {
            return testResults.Tests.Count;
        }

        public int PassedTestCases(TestResults testResults)
        {
            return testResults.Tests.Count(r => r.Status.ToLower() == "pass");
        }

        public int FailedTestCases(TestResults testResults)
        {
            return testResults.Tests.Count(r => r.Status.ToLower() == "fail");
        }

        public double AverageExecutionTime(TestResults testResults)
        {
            return testResults.Tests.Average(r => r.ExecutionTime);
        }

        public int MinExecutionTime(TestResults testResults)
        {
            return testResults.Tests.Min(r => r.ExecutionTime);
        }

        public int MaxExecutionTime(TestResults testResults)
        {
            return testResults.Tests.Max(r => r.ExecutionTime);
        }
    }
}
