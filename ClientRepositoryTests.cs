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
        private ClientRepository clientRepository;

        [SetUp]
        public void Setup()
        {
            clientRepository = new ClientRepository();
        }
        [TestCase]
        public void Ping()
        {
            var pinger = clientRepository.Ping("localhost", "4242");
            Assert.IsTrue(pinger);
        }
        [TestCase]
        public void GetInputDataAndWriteAnswer()
        {
            Input input = clientRepository.GetInputData("localhost", "4242");
            Assert.NotNull(input);
            clientRepository.WriteAnswer(new Output(input), "localhost", "4242");
        }
    }
}
