using BenchmarkDotNet.Attributes;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MathFunctions" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MathFunctions.svc or MathFunctions.svc.cs at the Solution Explorer and start debugging.
    public class MathFunctions : IMathFunctions
    {
        [Params(1, 2)]
        public int Number { get; set; }

        [Benchmark]
        public int Square()
        {
            return this.Number * this.Number;
        }

    }
}
