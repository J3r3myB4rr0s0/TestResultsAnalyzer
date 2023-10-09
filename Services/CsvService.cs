using System.Text;
using TestResultsAnalyzer.Models;

namespace TestResultsAnalyzer.Services
{
    /// <summary>
    /// Static service class for handling CSV file operations related to test metrics and results.
    /// </summary>
    public class CsvService
    {
        /// <summary>
        /// Writes test metrics and results into a CSV file.
        /// </summary>
        /// <param name="testResults">The TestResults object containing individual test cases.</param>
        /// <param name="csvFilePath">The path where the CSV file will be saved.</param>
        /// <param name="metrics">The TestMetrics object containing computed metrics for the test cases.</param>
        public static void WriteToCsv(TestResults testResults, string csvFilePath, TestMetrics metrics)
        {
            StringBuilder sb = new StringBuilder();

            // Writing general metrics to CSV
            sb.AppendLine("Metric,Value");
            sb.AppendLine($"Total Cases,{metrics.TotalCases}");
            sb.AppendLine($"Passed Cases,{metrics.PassedCases}");
            sb.AppendLine($"Failed Cases,{metrics.FailedCases}");
            sb.AppendLine($"Average Execution Time,{metrics.AverageTime}");
            sb.AppendLine($"Min Execution Time,{metrics.MinTime}");
            sb.AppendLine($"Max Execution Time,{metrics.MaxTime}");

            // Writing metrics related to passed cases by module
            foreach (var entry in metrics.PassedCasesByModule)
            {
                sb.AppendLine($"Passed Cases in {entry.Key},{entry.Value}");
            }

            // Writing metrics related to failed cases by module
            foreach (var entry in metrics.FailedCasesByModule)
            {
                sb.AppendLine($"Failed Cases in {entry.Key},{entry.Value}");
            }

            // Writing metrics related to test cases by tester
            foreach (var entry in metrics.TestCasesByTester)
            {
                sb.AppendLine($"Test Cases by {entry.Key},{entry.Value}");
            }

            // Writing total number of testers
            sb.AppendLine($"Total Testers,{metrics.TotalTesters}");

            // Writing individual test results to CSV
            sb.AppendLine();
            sb.AppendLine("Name,Status,ExecutionTime,Timestamp,Module,TesterName");
            foreach (var result in testResults.Tests)
            {
                sb.AppendLine($"{result.TestCaseName},{result.Status},{result.ExecutionTime},{result.Timestamp},{result.Module},{result.TesterName}");
            }

            // Saving CSV data to the specified file path
            File.WriteAllText(csvFilePath, sb.ToString());
        }
    }
}
