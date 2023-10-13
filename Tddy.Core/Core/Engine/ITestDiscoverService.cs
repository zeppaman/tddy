using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tddy.Core.Model;

namespace Xunit
{
   
    public abstract class ITestDiscoverService
    {

        public abstract List<TestCase> GetTestCases();
        public abstract void Execute(TestCase selector);

    }
}
