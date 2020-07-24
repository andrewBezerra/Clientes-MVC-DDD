using ClientesProdutos.Domain.Entities;
using ClientesProdutos.Infrastructure.Persistence;
using ClientesProdutos.Infrastructure.Persistence.Repositories.Produto;
using NUnit.Framework;

namespace ClientesProdutos.Infrastructure.Test
{
    [Category("Produto-Infrastructure-Repository")]
    public class ProdutoRepositoryTest
    {
        SQLServerDb Db;
        ProdutoRepository _pRep;
        ProdutoEntity ProdutoTeste;
        [SetUp]
        public void Setup()
        {
            ProdutoTeste = new ProdutoEntity("Filme de Romance 1", "Andrew");
            Db = new SQLServerDb("Server=.; Database=CLIENTESPRODUTOSDB; User ID=cpapp; Password=123123");
            _pRep = new ProdutoRepository(Db);
        }

        [Test]
        public void PodeAdicionarUmNovoProduto()
        {
            _pRep.Add(ProdutoTeste);
            var produtoCriado = _pRep.GetbyID(ProdutoTeste.ID);
            Assert.AreEqual(ProdutoTeste.ID, produtoCriado.ID);
            _pRep.Delete(produtoCriado);
        }
        [Test]
        public void PodeAlterarUmProduto()
        {
            _pRep.Add(ProdutoTeste);
            var produtoCriado = _pRep.GetbyID(ProdutoTeste.ID);
            produtoCriado.AlterarNome("Filme de Romance 2");
            _pRep.Update(produtoCriado);
            var produtoModificado = _pRep.GetbyID(ProdutoTeste.ID);
            Assert.AreEqual(produtoCriado.Nome, produtoModificado.Nome);
            _pRep.Delete(produtoModificado);
        }
        [Test]
        public void PodeRemoverUmProduto()
        {
            _pRep.Add(ProdutoTeste); 
            _pRep.Delete(ProdutoTeste);
            var produtobuscado = _pRep.GetbyID(ProdutoTeste.ID);

            Assert.AreEqual(null, produtobuscado);
            
        }
    }
}