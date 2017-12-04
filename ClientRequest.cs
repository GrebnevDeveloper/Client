using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Serializer serializer;
        public ClientRequest(string host, string port, string httpMethod, string method)
        {
            serializer = new Serializer();
            webRequest = WebRequest.Create($"http://{host}:{port}/{method}/");
            webRequest.Method = httpMethod;
            webRequest.Timeout = 1000;
        }

        //todo: СДелайте так чтобы метод мог работать с любым типом в сообщении, на дженериках (check)
        public T GetQuery<T>()
        {
            var response = webRequest.GetResponse();
            //todo: StreamReader нужно диспоузить (check)
            var sr = new StreamReader(response.GetResponseStream());
            var source = Encoding.UTF8.GetBytes(sr.ReadToEnd());
            sr.Dispose();
            return serializer.Deserialize<T>(source);
        }

        //todo: СДелайте так чтобы метод мог отсылать сообщение с любым серилихованным типом, на дженериках (check)
        public void PostQuery<T>(T obj)
        {
            if(obj != null)
            {
                //todo: StreamWriter нужно диспоузить (check)
                var sw = new StreamWriter(webRequest.GetRequestStream());
                sw.Write(Encoding.UTF8.GetString(serializer.Serialize<T>(obj)));
                sw.Dispose();
            }
        }

        public HttpStatusCode GetPing()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest) webRequest;
            HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
            response.Close();
            return response.StatusCode;
        }
    }

}
