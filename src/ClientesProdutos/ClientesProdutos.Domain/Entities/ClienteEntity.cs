using ClientesProdutos.Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using static ClientesProdutos.Domain.ValueObjects.CPFObject;

namespace ClientesProdutos.Domain.Entities
{
    public class ClienteEntity : AuditableEntity
    {
        public string Nome { get; private set; }
        public CPF Cpf { get; private set; }
        public IList<ProdutoEntity> Produtos { get; private set; }


        public ClienteEntity(string nome, 
                             string cpf,
                             string username
                            ) : base(username)
        {
            Nome = nome;
            Cpf = cpf;

            //FAST FAIL VALIDATION
            if (!Cpf.isValid)
            {
                this.Notifications.Items
                    .Add(("CPF", "CPF é inválido."));
                this.isValid = false;
            }
            if (this.Nome.Length > 150)
            {
                this.Notifications.Items
                    .Add(("Nome", 
                          "Nome não pode ter mais do que 150 caracteres"));
                this.isValid = false;
            }
        }
        public void AlterarNome(string novoNome) => this.Nome = novoNome;

        public void AdicionarProduto(ProdutoEntity produto)
        {
            if (Produtos.Count() == 15)
                return;

            Produtos.Add()

        }

    }
}