using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientRequest
    {
        WebRequest webRequest;
        public ClientRequest(string host, string port, string httpMethod, string method)
        {
            webRequest = WebRequest.Create($"http://{host}:{port}/{method}");
            webRequest.Method = httpMethod;
        }

        public Input GetQuery()
        {
            var response = webRequest.GetResponse();
            var sr = new StreamReader(response.GetResponseStream());
            var source = Encoding.UTF8.GetBytes(sr.ReadToEnd());
            return Serializer.Deserialize(source);
        }

        public void PostQuery(Output output)
        {
            if(output != null)
            {
                var sw = new StreamWriter(webRequest.GetRequestStream());
                sw.Write(Encoding.UTF8.GetString(Serializer.Serialize(output)));
            }
        }

        public HttpStatusCode GetPing()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest) webRequest;
            if(httpWebRequest.Connection != null)
            {
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                return response.StatusCode;
            }
            else
            {
                return HttpStatusCode.Conflict;
            }
        }
    }

}
