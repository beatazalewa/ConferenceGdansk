using System;
using BenchmarkDotNet.Attributes;

namespace Services
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static Random random = new Random();

        [Benchmark]
        public int GetRandomNumber()
        {
            return random.Next();
        }

    }
}
