using System;
using System.Threading;

namespace IssuesWithMemoryLeak
{
    class Program
    {

        private static int _requestsProcessed = 0;

        static void PrintStatistics(object state)
        {
            Console.Clear();
            Console.WriteLine("Requests processed: {0}", _requestsProcessed);
            Console.WriteLine("Memory usage: {0} mb", GC.GetTotalMemory(false) / 1024576);
        }

        static void Main(string[] args)
        {
            // Print processing statistics in a separate thread
            Timer timer = new Timer(PrintStatistics, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            // Handle an infinite stream of requests
            while (!Console.KeyAvailable)
            {
                Req request = Req.NextRequest();
                Res response = new Res(request);
                response.Send();
                Interlocked.Increment(ref _requestsProcessed);
            }

            GC.KeepAlive(timer);
        }
    }
}
