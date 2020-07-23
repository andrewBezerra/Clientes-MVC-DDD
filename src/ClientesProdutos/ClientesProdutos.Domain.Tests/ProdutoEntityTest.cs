using ClientesProdutos.Domain.Entities;
using NUnit.Framework;

namespace ClientesProdutos.Domain.Tests
{
    [Category("Produto-Domain-Entities")]
    public class ProdutoEntityTest
    {
        private ProdutoEntity produtoTeste;
        [SetUp]
        public void Setup()
        {
            produtoTeste = new ProdutoEntity("Filme de Ação", "Andrew");
        }

        [Test]
        public void PodeAlterarNome()
        {
            var nomeInicial = produtoTeste.Nome;
            produtoTeste.AlterarNome("Filme de Ação 2");

            Assert.AreEqual("Filme de Ação 2", produtoTeste.Nome);
            Assert.AreNotEqual(nomeInicial, produtoTeste.Nome);
            Assert.IsTrue(produtoTeste.isValid);
        }

        [Test]
        public void NaoPermiteMaisde150CaracteresNoNome()
        {
            string novonome = string.Empty;
            for (var count = 1; count <= 151; count++)
                novonome += "a";

            produtoTeste.AlterarNome(novonome);

            Assert.IsFalse(produtoTeste.isValid);
        }
        [Test]
        public void PermiteAte150CaracteresNoNome()
        {
            string novonome = string.Empty;
            for (var count = 1; count <= 150; count++)
                novonome += "a";

            produtoTeste.AlterarNome(novonome);

            Assert.IsTrue(produtoTeste.isValid);
        }
    }
}