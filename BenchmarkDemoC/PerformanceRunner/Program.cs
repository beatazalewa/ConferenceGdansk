using BenchmarkDotNet.Running;
using Services;


namespace PerformanceRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MathFunctions>();
            // var summary = BenchmarkRunner.Run<RandomNumberGenerator>();
        }
    }
}
