using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResultsAnalyzer.Models
{
    public class TestCaseResult
    {
        public string TestCaseName { get; set; }
        public string Status { get; set; }
        public int ExecutionTime { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
