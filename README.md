# Test Results Analyzer
## Overview
This solution calculates various metrics related to software testing, such as the total number of test cases, the number of passed and failed cases, and more. It reads test case results from a specific JSON file named **TestData.json** and writes the computed metrics to a CSV file.

## Requirements
- .NET SDK
- Newtonsoft.Json NuGet package

## Installation

1. Clone the repository: `git clone https://github.com/J3r3myB4rr0s0/TestResultsAnalyzer.git`
2. Navigate to the project directory and run `dotnet restore`

## How to Run

1. Place your JSON file with the test case results, named exactly as `TestData.json`, in the `InputData` folder.
2. Execute `dotnet run` in the terminal.

## JSON File Format

The JSON file must be named `TestData.json` and should have the following structure:

```json
{
  "Tests": [
    {
      "TestCaseName": "string",
      "Status": "string",
      "ExecutionTime": int,
      "Timestamp": "datetime",
      "Module": "string",
      "TesterName": "string"
    },
    ...
  ]
}
```
- **TestCaseName**: Name of the test case
- **Status**: Pass or fail status
- **ExecutionTime**: Time taken to execute the test in minutes
- **Timestamp**: When the test was executed
- **Module**: The module the test belongs to
- **TesterName**: Name of the tester who executed the test

## Output
Once executed, the program will create a folder called `Results` in the project root. Inside this folder, a CSV file named `TestResults+[timestamp].csv` will be generated. This file will contain all the computed metrics.
