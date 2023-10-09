using TestResultsAnalyzer.Models;
using TestResultsAnalyzer.Services;

namespace TestResultsAnalyzer
{
    /// <summary>
    /// The main Program class responsible for reading test results, computing metrics, and exporting data to a CSV file.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Define the path to the JSON file containing test results
            string jsonFilePath = "InputData/TestData.json";

            // Read test results from JSON file
            TestResults testResults = JsonService.ReadJsonFile(jsonFilePath);

            // Initialize the MetricsService class to compute metrics
            MetricsService metricsService = new MetricsService();

            // Compute test metrics
            TestMetrics metrics = new TestMetrics();
            metrics.TotalCases = metricsService.TotalTestCases(testResults);
            metrics.PassedCases = metricsService.PassedTestCases(testResults);
            metrics.FailedCases = metricsService.FailedTestCases(testResults);
            metrics.AverageTime = metricsService.AverageExecutionTime(testResults);
            metrics.MinTime = metricsService.MinExecutionTime(testResults);
            metrics.MaxTime = metricsService.MaxExecutionTime(testResults);
            metrics.PassedCasesByModule = metricsService.PassedCasesByModule(testResults);
            metrics.FailedCasesByModule = metricsService.FailedCasesByModule(testResults);
            metrics.TestCasesByTester = metricsService.TestCasesByTester(testResults);
            metrics.TotalTesters = metricsService.TotalTesters(testResults);

            // Create Results folder if it doesn't exist
            string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            string resultsDirectory = Path.Combine(projectDirectory, "Results");
            if (!Directory.Exists(resultsDirectory))
            {
                Directory.CreateDirectory(resultsDirectory);
            }

            // Generate a unique name for the CSV file
            string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string csvFileName = $"TestResults+{timestamp}.csv";
            string csvFilePath = Path.Combine(resultsDirectory, csvFileName);

            // Export metrics and test results to a CSV file
            CsvService.WriteToCsv(testResults, csvFilePath, metrics);
        }
    }
}