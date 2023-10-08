using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TestResultsAnalyzer.Models;

namespace TestResultsAnalyzer.Services
{
    public static class JsonService
    {
        public static TestResults ReadJsonFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            TestResults testResults = JsonConvert.DeserializeObject<TestResults>(jsonData);
            return testResults;
        }
    }
}
