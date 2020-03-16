using System;

namespace TestCPUCacheHits.TestsRowColumnAcess
{
    public class TestRowColumnAccess
    {
        public void Start()
        {
            Console.WriteLine("start");
            var test = new RowMajor(1000);
            test.FillMatrix();
            Console.WriteLine("fill matrix");
            Console.ReadLine();
            test.Run(10);
            Console.WriteLine("finish " + test.GetType().Name);
            Console.ReadLine();
        }
    }
}