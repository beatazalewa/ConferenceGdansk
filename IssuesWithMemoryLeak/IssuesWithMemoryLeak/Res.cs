using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesWithMemoryLeak
{
    class Res
    {
        private Req _request;
        private DbConn _dbConn;
        private byte[] _data;

        public Res(Req request)
        {
            _request = request;
            ResCache.Add(this);
        }

        public void Send()
        {
            _dbConn = new DbConn();
            _dbConn.Open();
            _data = _dbConn.GenerateResponse(_request.Id);
        }
    }
}
