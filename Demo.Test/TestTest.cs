using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.Test
{
    public class TestTest
    {
        [Fact()]
        public void MyTest() 
        {
            Console.WriteLine("My log");
            Assert.Equal(1, 1);
        }


        [Fact()]
        public void MyTest3()
        {

        }
    }
}
