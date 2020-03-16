namespace TestCPUCacheHits.TestsRowColumnAcess
{
    public class RowMajor : BaseMajor
    {
        public RowMajor(int matrixSize) : base(matrixSize)
        {

        }

        public override void Run(int cicles = 100)
        {
            for (int c = 0; c < cicles; c++)
            {
                var sum = 0;
                for (int i = 0; i < MaxSize; ++i)
                    for (int j = 0; j < MaxSize; ++j)
                        sum += Matrix[i, j];
            }
        }
    }
}
