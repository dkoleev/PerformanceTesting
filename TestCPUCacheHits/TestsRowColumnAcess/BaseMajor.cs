using System;

namespace TestCPUCacheHits.TestsRowColumnAcess
{
    public class BaseMajor
    {
        protected int MaxSize;
        protected static int[,] Matrix;

        public BaseMajor(int matrxiSize)
        {
            MaxSize = matrxiSize;
            Matrix = new int[MaxSize, MaxSize];
        }

        public virtual void Run(int cicles = 100)
        {

        }

        public void FillMatrix()
        {
            var random = new Random();
            for (int i = 0; i < MaxSize; i++)
            {
                for (int j = 0; j < MaxSize; j++)
                    Matrix[i, j] = random.Next(1, 1000);
            }
        }
    }
}