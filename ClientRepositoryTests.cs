using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [TestFixture]
    class ClientRepositoryTests
    {
        public ClientRepository clientRepository;

        [SetUp]
        public void Setup()
        {
            clientRepository = new ClientRepository();
        }
        [Test]
        public void Ping()
        {
            var pinger = clientRepository.Ping("127.0.0.1", "8080");
            Assert.IsTrue(pinger);
        }
        [Test]
        public void PostInputDataAndGetAnswer()
        {
            Input input = new Input();
            input.K = 10;
            input.Sums = new decimal[] { 1.01M, 2.02M };
            input.Muls = new int[] { 1, 4 };
            clientRepository.PostInputData(input, "127.0.0.1", "8080");
            Output output = clientRepository.GetAnswer("127.0.0.1", "8080");
            Output outputOrig = new Output(input);
            Assert.AreEqual(outputOrig, output);      
        }
    }
}
