using ClientesProdutos.Domain.Entities;
using NUnit.Framework;

namespace ClientesProdutos.Domain.Tests
{
    [Category("Cliente-Domain-Entities")]
    public class ClienteEntityTest
    {
        private ClienteEntity ClienteTeste;

        private ClienteEntity ClienteCPFInvalido;

        [SetUp]
        public void Setup()
        {
            ClienteTeste =
            new ClienteEntity("Jo�o da Silva",
                              "18480847816",
                              "Andrew");

            ClienteCPFInvalido =
            new ClienteEntity("Arthur da Silva",
                              "00000000000",
                              "Andrew");
        }

        [Test]
        public void PodeAlterarNome()
        {
            ClienteTeste.AlterarNome("Wilson da Silva");
            Assert.AreEqual("Wilson da Silva", ClienteTeste.Nome);
            Assert.AreNotEqual("Jo�o da Silva", ClienteTeste.Nome);
            Assert.IsTrue(ClienteTeste.isValid);
        }

        [Test]
        public void CPFValidoRetornaValido()
        {
            Assert.IsTrue(ClienteTeste.Cpf.isValid);
            Assert.IsTrue(ClienteTeste.isValid);
        }

        [Test]
        public void CPFInvalidoRetornaInvalido()
        {
            Assert.IsFalse(ClienteCPFInvalido.Cpf.isValid);
            Assert.IsFalse(ClienteCPFInvalido.isValid);
        }
        [Test]
        public void PodeIncluirProdutos()
        {
            var produto = new ProdutoEntity("Filme de A��o", "Andrew");

            var qtdProdutosInicial = ClienteTeste.Produtos.Count;
            ClienteTeste.AdicionarProduto(produto);

            Assert.AreEqual(0, qtdProdutosInicial);
            Assert.AreEqual(1, ClienteTeste.Produtos.Count);
            Assert.IsTrue(ClienteTeste.isValid);
        }
        [Test]
        public void PodeRemoverProdutos()
        {
            var produto = new ProdutoEntity("Filme de A��o", "Andrew");

            ClienteTeste.AdicionarProduto(produto);
            var qtdProdutosInicial = ClienteTeste.Produtos.Count;
            ClienteTeste.RemoverProduto(produto);

            Assert.AreEqual(1, qtdProdutosInicial);
            Assert.AreEqual(0, ClienteTeste.Produtos.Count);
            Assert.IsTrue(ClienteTeste.isValid);
        }
        [Test]
        public void NaoPermiteMaisde15FilmesPorCliente()
        {

            for (var count = 1; count <= 16; count++)
                ClienteTeste.AdicionarProduto(
                    new ProdutoEntity($"Filme de A��o {count}", "Andrew")
                    );


            Assert.IsFalse(ClienteTeste.isValid);
        }
        [Test]
        public void NaoPermiteMaisde150CaracteresNoNome()
        {
            string novonome = string.Empty;
            for (var count = 1; count <= 151; count++)
                novonome += "a";

            ClienteTeste.AlterarNome(novonome);

            Assert.IsFalse(ClienteTeste.isValid);
        }
        [Test]
        public void PermiteAte150CaracteresNoNome()
        {
            string novonome = string.Empty;
            for (var count = 1; count <= 150; count++)
                novonome += "a";

            ClienteTeste.AlterarNome(novonome);

            Assert.IsTrue(ClienteTeste.isValid);
        }
    }
}