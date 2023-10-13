using Tddy.Core.Model;

namespace Xunit
{
    public abstract class ITestDiscoverService
    {
        public abstract List<TestCase> GetTestCases();

        public abstract void Execute(TestCase selector);
    }
}