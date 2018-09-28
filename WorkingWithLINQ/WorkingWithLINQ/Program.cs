using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq;


namespace WorkingWithLINQ
{
    public class DerivedClass
    {
        private const int min = 100000;
        private const int max = 999999 + 1;

        // Find average number of unique digits in numbers between Min and Max value

        [Benchmark]
        public static double SumUsingForLoops()
        {
            int sum = 0;

            for (int i = min; i < max; ++i)
            {
                var firstArray = new int[10];
                var num = i;
                while (num > 0)
                {
                    firstArray[num % 10] += 1;
                    num /= 10;
                }

                for (int f = 0; f < firstArray.Length; ++f)
                    if (firstArray[f] == 1) ++sum;
            }

            return (double)sum / (max - min);
        }

        [Benchmark]
        public static double SumUsingForLoopsAndString()
        {
            int sum = 0;
            for (int i = min; i < max; ++i)
            {
                var secondArray = new int[10];
                var k = i.ToString();
                for (var a = 0; a < k.Length; ++a)
                    secondArray[k[a] - '0'] += 1;
                for (int s = 0; s < secondArray.Length; ++s)
                    if (secondArray[s] == 1) // then this is a unique digit
                        ++sum;
            }
            return (double)sum / (max - min);
        }

        [Benchmark]
        public static double SumUsingLinq()
        {
            return Enumerable.Range(min, max - min)
                .Select(i => i.ToString()
                                .AsEnumerable()
                                .GroupBy(
                                c => c,
                                c => c,
                                (k, g) => new
                                {
                                    Character = k,
                                    Count = g.Count()
                                })
                                .Count(g => g.Count == 1))
                .Average();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DerivedClass.SumUsingForLoops());
            //Console.WriteLine(DerivedClass.SumUsingForLoopsAndString());
            //Console.WriteLine(DerivedClass.SumUsingLinq());
            //Console.ReadKey();

            BenchmarkRunner.Run<DerivedClass>();
        }
    }
}
