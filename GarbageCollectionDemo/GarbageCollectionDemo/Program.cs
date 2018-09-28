using System;

namespace GarbageCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Calculator calculator = new Calculator())
            {
                Console.WriteLine($"120 / 2 = {calculator.Divide(120, 2)}");             
            }
            Console.WriteLine("Program finishing");
            Console.ReadKey();
        }
    }
}
