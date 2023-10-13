using Spectre.Console;
using Tddy.Core.Model;
using Xunit.Runners;

namespace Tddy.Core.Engine.Xunit
{
    public class TestRunner
    {
        private static readonly object ConsoleLock = new();

        private static readonly ManualResetEvent Finished = new(false);

        public int Result;

        private readonly string _assemblyFileName;

        private AssemblyRunner runner;

        public TestRunner(string assemblyFileName)
        {
            _assemblyFileName = assemblyFileName;
            runner = AssemblyRunner.WithoutAppDomain(_assemblyFileName);
        }

        public int Start(TestCase test)
        {
            runner.OnDiscoveryComplete = OnDiscoveryComplete;
            runner.OnExecutionComplete = OnExecutionComplete;
            runner.OnTestFailed = OnTestFailed;
            runner.OnTestSkipped = OnTestSkipped;
            runner.TestCaseFilter = (x) =>
            {
                return x.TestMethod.Method.Name == test.MethodName;
            };

            AnsiConsole.WriteLine("Discovering...");
            runner.Start();

            Finished.WaitOne();
            // Finished.Dispose();

            return Result;
        }

        private void OnDiscoveryComplete(DiscoveryCompleteInfo info)
        {
            lock (ConsoleLock)
                AnsiConsole.WriteLine($"Running {info.TestCasesToRun} of {info.TestCasesDiscovered} tests...");
        }

        private void OnExecutionComplete(ExecutionCompleteInfo info)
        {
            lock (ConsoleLock)
                AnsiConsole.WriteLine($"Finished: {info.TotalTests} tests in {Math.Round(info.ExecutionTime, 3)}s ({info.TestsFailed} failed, {info.TestsSkipped} skipped)");

            Finished.Set();
        }

        private void OnTestFailed(TestFailedInfo info)
        {
            lock (ConsoleLock)
            {
                //AnsiConsole.ForegroundColor = ConsoleColor.Red;

                AnsiConsole.WriteLine("[FAIL] {0}: {1}", info.TestDisplayName, info.ExceptionMessage);
                if (info.ExceptionStackTrace != null)
                {
                    AnsiConsole.WriteLine(info.ExceptionStackTrace);
                }

                // AnsiConsole.ResetColor();
            }

            Result = 1;
        }

        private void OnTestSkipped(TestSkippedInfo info)
        {
            lock (ConsoleLock)
            {
                // Console.ForegroundColor = ConsoleColor.Yellow;
                AnsiConsole.WriteLine("[SKIP] {0}: {1}", info.TestDisplayName, info.SkipReason);
                // Console.ResetColor();
            }
        }
    }
}