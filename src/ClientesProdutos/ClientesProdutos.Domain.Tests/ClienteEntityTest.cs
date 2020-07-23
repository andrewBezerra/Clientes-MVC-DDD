using ClientesProdutos.Domain.Entities;
using NUnit.Framework;

namespace ClientesProdutos.Domain.Tests
{
    [Category("Domain-Entities")]
    public class ClienteEntityTest
    {
        ClienteEntity ClienteTeste = new ClienteEntity("Jo�o da Silva", "18480847816", "Andrew");
        ClienteEntity ClienteCPFInvalido = new ClienteEntity("Arthur da Silva", "00000000000", "Andrew");
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PodeAlterarNome()
        {
            
            ClienteTeste.AlterarNome("Jos� da Silva");
            Assert.AreEqual("Jos� da Silva", ClienteTeste.Nome);
            Assert.AreNotEqual("Jo�o da Silva", ClienteTeste.Nome);
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