using Newtonsoft.Json;
using TestResultsAnalyzer.Models;

namespace TestResultsAnalyzer.Services
{
    /// <summary>
    /// Static service class for handling JSON file operations related to test results.
    /// </summary>
    public static class JsonService
    {
        /// <summary>
        /// Reads a JSON file from the given path and deserializes it into a TestResults object.
        /// </summary>
        /// <param name="filePath">The path to the JSON file.</param>
        /// <returns>A TestResults object containing the deserialized test results.</returns>
        public static TestResults ReadJsonFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            TestResults testResults = JsonConvert.DeserializeObject<TestResults>(jsonData);
            return testResults;
        }
    }
}
