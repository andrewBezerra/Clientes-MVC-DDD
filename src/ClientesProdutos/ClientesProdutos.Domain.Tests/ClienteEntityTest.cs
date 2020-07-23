using ClientesProdutos.Domain.Entities;
using NUnit.Framework;

namespace ClientesProdutos.Domain.Tests
{
    [Category("Domain-Entities")]
    public class ClienteEntityTest
    {
        ClienteEntity ClienteTeste = new ClienteEntity("João da Silva", "18480847816", "Andrew");
        ClienteEntity ClienteCPFInvalido = new ClienteEntity("Arthur da Silva", "00000000000", "Andrew");
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PodeAlterarNome()
        {
            
            ClienteTeste.AlterarNome("José da Silva");
            Assert.AreEqual("José da Silva", ClienteTeste.Nome);
            Assert.AreNotEqual("João da Silva", ClienteTeste.Nome);
        }
        [Test]          
        public void CPFValidoRetornaValido()
        {
            Assert.IsTrue(ClienteTeste.Cpf.isValid);
            
        }
        [Test]
        public void CPFInvalidoRetornaInvalido()
        {
            Assert.IsFalse(ClienteCPFInvalido.Cpf.isValid);
            Assert.Pass(ClienteCPFInvalido.Notifications.ToString());
        }
    }
}