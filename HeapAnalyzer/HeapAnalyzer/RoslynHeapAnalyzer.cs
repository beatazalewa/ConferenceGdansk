using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapAnalyzer
{
    class RoslynHeapAnalyzer
    {
        static void ParamsMethod(params string[] a)
        {
            ParamsMethod("We usually do this"); //implicit, so warning
            ParamsMethod(new[] { "We usually do this" }); //explicit new, so only informational
        }

        static void Foo()
        {
        }

        static void FooCalling(Action a, Action b)
        {
            FooCalling(Foo, new Action(Foo)); //both do the same thing, implicit vs explicit
        }

        static void SoManyObjects()
        {
            var words = new[] { "foo", "bar", "baz", "beer" };
            var actions = new List<Action>();
            foreach (string word in words) //<-- captured closure
            {
                actions.Add(() => Console.WriteLine(word)); //<-- reason for closure capture
            }
        }
    }
}
