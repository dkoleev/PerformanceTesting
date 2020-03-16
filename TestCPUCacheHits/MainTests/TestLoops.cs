using System;

namespace TestCPUCacheHits.MainTests
{
    public class TestLoops
    {
        public void Start() 
        {
          //  Test2Loops();
            //RunLoop2();
            TestCacheLevelsJumps();
        }

        private void TestCacheLevelsJumps()
        {
            int[] arr = new int[64 * 1024 * 1024];
            int steps = 64 * 1024 * 1024; // Arbitrary number of steps
            int lengthMod = arr.Length - 1;
            for (int i = 0; i < steps; i++)
            {
                arr[(i * 16) & lengthMod]++; // (x & lengthMod) is equal to (x % arr.Length)
            }
        }

        private void Test2Loops() 
        {
            int[] arr = new int[64 * 1024 * 1024];

            Console.WriteLine("start test");
            Console.ReadLine();

            for (int i = 0; i < arr.Length; i += 16)
                arr[i] *= 3;

            Console.WriteLine("first finish");
            Console.ReadLine();

            for (int i = 0; i < arr.Length; i++) 
                arr[i] *= 3;

            Console.WriteLine("second finish");
            Console.ReadLine();
        }

        private void RunLoop() 
        {
            int[] arr = new int[64 * 1024 * 1024];

            for (int i = 0, j = 0; i < arr.Length; i += 1, j += 1)
            {
                if (j >= arr.Length)
                    j = 0;
                arr[j] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 1, j += 4)
            {
                if (j >= arr.Length)
                    j = 0;
                arr[j] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 1, j += 8)
            {
                if (j >= arr.Length)
                    j = 0;
                arr[j] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 1, j += 16)
            {
                if (j >= arr.Length)
                    j = 0;
                arr[j] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 1, j += 32)
            {
                if (j >= arr.Length)
                    j = 0;
                arr[j] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 1, j += 64)
            {
                if (j >= arr.Length)
                    j = 0;
                arr[j] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 1, j += 128)
            {
                if (j >= arr.Length)
                    j = 0;
                arr[j] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 1, j += 256)
            {
                if (j >= arr.Length)
                    j = 0;
                arr[j] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 1, j += 512)
            {
                if (j >= arr.Length)
                    j = 0;
                arr[j] *= 3;
            }
            Console.ReadLine();
        }

        private void RunLoop2()
        {
            int[] arr = new int[64 * 1024 * 1024];

            for (int i = 0, j = 0; i < arr.Length; i += 1)
            {
                arr[i] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 2)
            {
                arr[i] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 4)
            {
                arr[i] *= 3;
            }
            Console.ReadLine();
            for (int i = 0, j = 0; i < arr.Length; i += 8)
            {
                arr[i] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 16)
            {
                arr[i] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 32)
            {
                arr[i] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 64)
            {
                arr[i] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 128)
            {
                arr[i] *= 3;
            }
            Console.ReadLine();

            for (int i = 0, j = 0; i < arr.Length; i += 256)
            {
                arr[i] *= 3;
            }
            Console.ReadLine();
        }
    }
}