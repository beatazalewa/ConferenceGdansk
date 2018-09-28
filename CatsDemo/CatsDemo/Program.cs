using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat myCat = new Cat("Simon", 1);
            myCat.Purr();

            Cat myMotherCat = new Cat("Milka", 3);
            myMotherCat.Scratch();

            //Simon no longer referenced after this line executes
            myCat = null;
            Console.WriteLine("****************");

            Cat myCousinCat = new Cat("Garfield", 5);
            Console.WriteLine(string.Format("Garfield is in generation {0}", GC.GetGeneration(myCousinCat)));

            GC.Collect();
            Console.WriteLine(string.Format("Garfield is in generation {0}", GC.GetGeneration(myCousinCat)));

            GC.Collect();
            Console.WriteLine(string.Format("Garfield is in generation {0}", GC.GetGeneration(myCousinCat)));

            Cat myDaughterCat = new Cat("Felix", 8);
            myDaughterCat.Purr();
            if (myDaughterCat is IDisposable)
                ((IDisposable)myDaughterCat).Dispose();
            /*
            using (Cat myHusbandCat = new Cat("Fiona", 4))
            {
                myHusbandCat.Purr();
            }
            */
            Console.ReadKey();
        }
    }

    class Cat //:IDisposable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Cat (string n, int a)
        {
            Name = n;
            Age = a;
        }

        public void Purr()
        {
            Console.WriteLine("Cat {0} purrs.", this.Name);
        }

        public void Scratch()
        {
            Console.WriteLine("Cat {0} is scratching everything.", this.Name);
        }
    }
}
