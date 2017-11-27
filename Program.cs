using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            string port = Console.ReadLine();
            ClientRepository client = new ClientRepository();
            if(client.Ping(host, port))
            {
                Input input = client.GetInputData(host, port);
                client.WriteAnswer(new Output(input), host, port);
            }
        }
    }
}
