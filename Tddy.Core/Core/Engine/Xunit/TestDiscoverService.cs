using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tddy.Core.Model;
using Xunit;
using Xunit.Runners;

namespace Tddy.Core.Engine.Xunit
{
    public class TestDiscoverService : ITestDiscoverService
    {
        TestRunner runner;
        public TestDiscoverService() {
             runner = new TestRunner(Assembly.GetEntryAssembly().Location);
        }
        public List<TestCase> GetTestCases()
        {
            var cases = new List<TestCase>();
            var entry=Assembly.GetEntryAssembly();

            var types = entry.GetTypes();

            foreach (var item in types)
            {
                foreach(var method in item.GetMethods()) {

                    if (method.GetCustomAttribute<FactAttribute>() != null)
                    {
                        cases.Add(new TestCase()
                        {
                            Class=new ClassRef() { 
                                Name=item.Name,
                                FullyQualifiedAssemblyName=item.FullName+","+item.AssemblyQualifiedName,
                                TypeName=item.Assembly.FullName
                            },
                            MethodName=method.Name,
                            
                            

                        });
                    }
                
                }               
            }
            return cases;
        }

        public void Execute(TestCase selector)
        {


           
            runner.Start(selector);
            
        }
    }
}
