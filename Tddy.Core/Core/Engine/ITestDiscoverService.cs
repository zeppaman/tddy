using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tddy.Core.Model;

namespace Xunit
{
   
    public interface ITestDiscoverService
    {

        public List<TestCase> GetTestCases();
        public void Execute(TestCase selector);

    }
}
