using ClientesProdutos.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientesProdutos.Domain.Entities
{
    public class ProdutoEntity : AuditableEntity
    {
        public string Nome { get; private set; }
        public ProdutoEntity(string nome,
                             string username
                            ) : base(username)
        {
            Nome = nome;
            if (this.Nome.Length > 150)
            {
                this.Notifications.Items
                    .Add(("Nome",
                          "Nome não pode ter mais do que 150 caracteres"));
                this.isValid = false;
            }
        }

        public void AlterarNome(string novoNome) => this.Nome = novoNome;
    }
}
