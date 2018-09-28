using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace MemoryDiagnoser
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarksTest>();
        }
    }
    [MemoryDiagnoser]
    [RyuJitX64Job, LegacyJitX86Job] // let's run the benchmarks for 32 & 64 bit
    public class BenchmarksTest
    {
        [Benchmark]
        public byte[] EmptyArray() => Array.Empty<byte>();

        [Benchmark]
        public byte[] EightBytes() => new byte[8];

        [Benchmark]
        public byte[] SimpleLinqQuery()
        {
            return Enumerable
                .Range(0, 50)
                .Where(i => i % 2 == 0)
                .Select(i => (byte)i)
                .ToArray();
        }
    }
}
