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
            var pinger = clientRepository.Ping("127.0.0.1", "8080");
            Assert.IsTrue(pinger);
        }
        [TestCase]
        public void GetInputDataAndWriteAnswer()
        {
            var input = clientRepository.GetInputData("127.0.0.1", "8080");
            Assert.NotNull(input);
            Assert.IsInstanceOf(typeof(Input), input);
            clientRepository.WriteAnswer(new Output(input), "127.0.0.1", "8080");
        }
    }
}
