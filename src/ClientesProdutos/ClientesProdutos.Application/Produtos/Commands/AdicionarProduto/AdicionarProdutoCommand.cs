using ClientesProdutos.Application.Shared.Commands;
using ClientesProdutos.Domain.Entities;
using ClientesProdutos.Infrastructure.Persistence.Repositories.Interfaces;
using System;

namespace ClientesProdutos.Application.Produtos.Commands.AdicionarProduto
{
    public class AdicionarProdutoCommand : ICommand

    {
        public AdicionarProdutoCommand(string nome, string username)
        {
            Nome = nome;
            UserName = username;
        }

        public bool isValid { get; private set; }

        public string Nome { get; private set; }
        public string UserName { get; private set; }
    }

    public class AdicionarProdutoCommandHandler : ICommandHandler<AdicionarProdutoCommand>
    {
        private IProdutoRepository _rep;

        public AdicionarProdutoCommandHandler(IProdutoRepository rep)
        {
            _rep = rep;
            
        }

        public ICommandResult Handle(AdicionarProdutoCommand command)
        {
            var produto = new ProdutoEntity(command.Nome,command.us)
        }
    }
}