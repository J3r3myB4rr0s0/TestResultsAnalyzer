using TestResultsAnalyzer.Models;
using TestResultsAnalyzer.Services;

namespace TestResultsAnalyzer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Ruta al archivo JSON
            string jsonFilePath = "InputData/TestData.json";

            // Leer datos del archivo JSON
            TestResults testResults = JsonService.ReadJsonFile(jsonFilePath);

            // Inicializar MetricsService
            MetricsService metricsService = new MetricsService();

            // Calcular métricas
            int totalCases = metricsService.TotalTestCases(testResults);
            int passedCases = metricsService.PassedTestCases(testResults);
            int failedCases = metricsService.FailedTestCases(testResults);
            double averageTime = metricsService.AverageExecutionTime(testResults);
            double minTime = metricsService.MinExecutionTime(testResults);
            double maxTime = metricsService.MaxExecutionTime(testResults);

            // Mostrar resultados
            Console.WriteLine($"Total Cases: {totalCases}");
            Console.WriteLine($"Passed Cases: {passedCases}");
            Console.WriteLine($"Failed Cases: {failedCases}");
            Console.WriteLine($"Average Execution Time: {averageTime}");
            Console.WriteLine($"Min Execution Time: {minTime}");
            Console.WriteLine($"Max Execution Time: {maxTime}");

            // Exportar resultados a CSV
            CsvService.WriteToCsv(testResults);
        }
    }
}