using TestResultsAnalyzer.Models;

namespace TestResultsAnalyzer.Services
{
    /// <summary>
    /// Service class responsible for calculating various test metrics.
    /// </summary>
    public class MetricsService
    {
        /// <summary>
        /// Calculates the total number of test cases.
        /// </summary>
        /// <returns>Total number of test cases.</returns>
        public int TotalTestCases(TestResults testResults)
        {
            return testResults.Tests.Count;
        }

        /// <summary>
        /// Calculates the total number of passed test cases.
        /// </summary>
        /// <returns>Total number of passed test cases.</returns>
        public int PassedTestCases(TestResults testResults)
        {
            return testResults.Tests.Count(r => r.Status.ToLower() == "passed");
        }

        /// <summary>
        /// Calculates the total number of failed test cases.
        /// </summary>
        /// <returns>Total number of failed test cases.</returns>
        public int FailedTestCases(TestResults testResults)
        {
            return testResults.Tests.Count(r => r.Status.ToLower() == "failed");
        }

        /// <summary>
        /// Calculates the average execution time of test cases.
        /// </summary>
        /// <returns>Average execution time.</returns>
        public double AverageExecutionTime(TestResults testResults)
        {
            return testResults.Tests.Average(r => r.ExecutionTime);
        }

        /// <summary>
        /// Finds the minimum execution time among test cases.
        /// </summary>
        /// <returns>Minimum execution time.</returns>
        public int MinExecutionTime(TestResults testResults)
        {
            return testResults.Tests.Min(r => r.ExecutionTime);
        }

        /// <summary>
        /// Finds the maximum execution time among test cases.
        /// </summary>
        /// <returns>Maximum execution time.</returns>
        public int MaxExecutionTime(TestResults testResults)
        {
            return testResults.Tests.Max(r => r.ExecutionTime);
        }

        /// <summary>
        /// Groups the passed test cases by module and counts them.
        /// </summary>
        /// <returns>A Dictionary mapping each module to the count of passed test cases.</returns>
        public Dictionary<string, int> PassedCasesByModule(TestResults testResults)
        {
            return testResults.Tests
                .Where(r => r.Status.ToLower() == "passed")
                .GroupBy(r => r.Module)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Groups the failed test cases by module and counts them.
        /// </summary>
        /// <returns>A Dictionary mapping each module to the count of failed test cases.</returns>
        public Dictionary<string, int> FailedCasesByModule(TestResults testResults)
        {
            return testResults.Tests
                .Where(r => r.Status.ToLower() == "failed")
                .GroupBy(r => r.Module)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Groups test cases by tester and counts them.
        /// </summary>
        /// <returns>A Dictionary mapping each tester to the count of test cases they executed.</returns>
        public Dictionary<string, int> TestCasesByTester(TestResults testResults)
        {
            return testResults.Tests
                .GroupBy(r => r.TesterName)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Calculates the total number of distinct testers.
        /// </summary>
        /// <returns>Total number of distinct testers.</returns>
        public int TotalTesters(TestResults testResults)
        {
            return testResults.Tests.Select(r => r.TesterName).Distinct().Count();
        }
    }
}
