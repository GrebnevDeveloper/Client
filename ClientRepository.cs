using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientRepository
    {
        public Input GetInputData(string host, string port)
        {
            return new ClientRequest(host, port, "GET", "GetInputData").GetQuery();
        }
        public void WriteAnswer(Output output, string host, string port)
        {
            new ClientRequest(host, port, "POST", "WriteAnswer").PostQuery(output);
        }

        public bool Ping(string host, string port)
        {
            if(new ClientRequest(host, port, "GET", "Ping")
                .GetPing()
                .Equals(HttpStatusCode.OK))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
