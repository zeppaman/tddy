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