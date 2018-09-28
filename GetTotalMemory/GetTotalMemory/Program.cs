using System;
using System.Collections.Generic;

namespace GetTotalMemory
{
    class Program
    {
        /* You can call the GC.GetTotalMemory function to find out the total # bytes you’ve allocated so far on the managed heap.  Note that this number does not include other memory that your process may have allocated, including things like memory allocated in unmanaged code. */
        static void Main()
        {
            try
            {
                List<byte[]> _bigList = new List<byte[]>();
            #if DEBUG
                GC.Collect();
            #endif
                Console.WriteLine(string.Format("Before we start, total memory allocated {0} bytes", GC.GetTotalMemory(false)));

                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey();

                    int size = 1024 * 1024 * 100;  // 100MB
                    byte[] data = new byte[size];

                    Array.Clear(data, 0, size);
                   
                   _bigList.Add(data);

                    #if DEBUG
                    GC.Collect();
                    #endif
                    Console.WriteLine(string.Format("Total memory allocated now {0} bytes", GC.GetTotalMemory(false)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
}
