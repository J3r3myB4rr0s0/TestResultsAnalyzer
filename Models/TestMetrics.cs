namespace TestResultsAnalyzer.Models
{
    /// <summary>
    /// Holds various metrics related to test cases.
    /// </summary>
    public class TestMetrics
    {

        // Total number of test cases executed.
        public int TotalCases { get; set; }
        // Total number of test cases that passed.
        public int PassedCases { get; set; }
        // Total number of test cases that failed.
        public int FailedCases { get; set; }
        // Average execution time of all test cases.
        public double AverageTime { get; set; }
        // Minimum execution time among all test cases.
        public double MinTime { get; set; }
        // Maximum execution time among all test cases.
        public double MaxTime { get; set; }
        // Number of test cases passed, categorized by module.
        public Dictionary<string, int> PassedCasesByModule { get; set; }
        // Number of test cases failed, categorized by module.
        public Dictionary<string, int> FailedCasesByModule { get; set; }
        // Number of test cases executed by each tester.
        public Dictionary<string, int> TestCasesByTester { get; set; }
        // Total number of testers who participated.
        public int TotalTesters { get; set; }

        // Initializes new instances of Dictionaries to avoid null reference issues.
        public TestMetrics()
        {
            PassedCasesByModule = new Dictionary<string, int>();
            FailedCasesByModule = new Dictionary<string, int>();
            TestCasesByTester = new Dictionary<string, int>();
        }
    }
}
