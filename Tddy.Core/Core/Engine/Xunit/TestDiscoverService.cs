using System.Reflection;
using Tddy.Core.Model;
using Xunit;

namespace Tddy.Core.Engine.Xunit
{
    public class XunitTestDiscoverService : ITestDiscoverService
    {
        private TestRunner runner;

        public XunitTestDiscoverService()
        {
            runner = new TestRunner(Assembly.GetEntryAssembly().Location);
        }

        public override List<TestCase> GetTestCases()
        {
            var cases = new List<TestCase>();
            var entry = Assembly.GetEntryAssembly();

            var types = entry.GetTypes();

            foreach (var item in types)
            {
                foreach (var method in item.GetMethods())
                {
                    if (method.GetCustomAttribute<FactAttribute>() != null)
                    {
                        cases.Add(new TestCase()
                        {
                            Class = new ClassRef()
                            {
                                Name = item.Name,
                                FullyQualifiedAssemblyName = item.FullName + "," + item.AssemblyQualifiedName,
                                TypeName = item.Assembly.FullName
                            },
                            MethodName = method.Name,
                        });
                    }
                }
            }
            return cases;
        }

        public override void Execute(TestCase selector)
        {
            runner.Start(selector);
        }
    }
}