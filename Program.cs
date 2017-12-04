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
                Console.WriteLine("OK");
                Input input = new Input();
                input.K = 10;
                input.Sums = new decimal[] { 1.01M, 2.02M };
                input.Muls = new int[] { 1, 4 };
                client.PostInputData(input, host, port);
                Output output = client.GetAnswer(host, port);
            }
        }
    }
}
