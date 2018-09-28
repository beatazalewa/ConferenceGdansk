using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee josh = new Employee("Josh");
            josh.PaySalary();
            josh.PayRise();
            josh.PaySalary();
            //Josh no longer exists after this line executes
            josh = null;
            Employee mary = new Employee("Mary");
            mary.PaySalary();
            mary.PayRise();
            mary.PaySalary();
            mary = null;
            GC.AddMemoryPressure(Int32.MaxValue);
            GC.WaitForPendingFinalizers();
            Employee maxima = new Employee("Maxima");
            maxima.PaySalary();
            maxima.PayRise();
            maxima.PaySalary();
            maxima = null;
            GC.AddMemoryPressure(Int32.MaxValue);
            GC.WaitForPendingFinalizers();
            Console.ReadLine();
            GC.RemoveMemoryPressure(Int32.MaxValue);
        }
    }
}
