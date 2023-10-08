using System.Text;
using TestResultsAnalyzer.Models;

namespace TestResultsAnalyzer.Services
{
    public class CsvService
    {
        public static void WriteToCsv(TestResults testResults)
        {
            // Crear una carpeta 'Results' si no existe
            string dirPath = "Results";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            // Crear el nombre del archivo con un sello de tiempo
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = $"TestResults+{timeStamp}.csv";
            string csvFilePath = Path.Combine(dirPath, fileName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name,Status,ExecutionTime,Timestamp");

            foreach (var result in testResults.Tests)
            {
                sb.AppendLine($"{result.TestCaseName},{result.Status},{result.ExecutionTime},{result.Timestamp}");
            }

            File.WriteAllText(csvFilePath, sb.ToString());
        }
    }
}
