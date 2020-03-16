using TestCPUCacheHits.TestsRowColumnAcess;
using TestCPUCacheHits.MainTests;

namespace TestCPUCacheHits
{
    class Program
    {
        static void Main(string[] args)
        {
           // var rowColumnTest = new TestRowColumnAccess();
           // rowColumnTest.Start();

            var testLoops = new TestLoops();
            testLoops.Start();
        }
    }
}