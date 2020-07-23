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
            new ClienteEntity("João da Silva",
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
        }
        [Test]
        public void PodeIncluirProdutos()
        {
            var produto = new ProdutoEntity("Filme de Ação", 
                                                      "Andrew");

            var qtdProdutosInicial = ClienteTeste.Produtos.Count;
            ClienteTeste.AdicionarProduto(produto);

            Assert.AreEqual(0, qtdProdutosInicial);
            Assert.AreEqual(1, ClienteTeste.Produtos.Count);
        }
        [Test]
        public void PodeRemoverProdutos()
        {
            var produto = new ProdutoEntity("Filme de Ação", "Andrew");

            ClienteTeste.AdicionarProduto(produto);
            var qtdProdutosInicial = ClienteTeste.Produtos.Count;
            ClienteTeste.RemoverProduto(produto);

            Assert.AreEqual(1, qtdProdutosInicial);
            Assert.AreEqual(0, ClienteTeste.Produtos.Count);
        }
        [Test]
        public void NaoPermiteMaisde15FilmesPorCliente()
        {

            for (var count = 1; count <= 16; count++)
                ClienteTeste.AdicionarProduto(
                    new ProdutoEntity($"Filme de Ação {count}", "Andrew")
                    );


            Assert.AreEqual(15, ClienteTeste.Produtos.Count);
        }
    }
}