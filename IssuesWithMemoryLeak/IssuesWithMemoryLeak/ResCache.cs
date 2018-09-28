using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesWithMemoryLeak
{
    class ResCache
    {
        private static List<Res> _cache = new List<Res>();

        public static void Add(Res response)
        {
            _cache.Add(response);
        }
    }
}
