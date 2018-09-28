using System;
using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;

namespace Services
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static Random random = new Random();

        [Benchmark]
        public int GetRandomNumber()
        {
            using (var randomNumberProvider = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[sizeof(Int32)];

                randomNumberProvider.GetBytes(randomBytes);

                return BitConverter.ToInt32(randomBytes, 0);
            }
        }
    }
}
