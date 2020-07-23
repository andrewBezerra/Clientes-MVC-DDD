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
        public IList<ProdutoEntity> Produtos { get; private set; } = new List<ProdutoEntity>();

        public ClienteEntity(string nome,
                             string cpf,
                             string username
                            ) : base(username)
        {
            Nome = nome;
            Cpf = cpf;

            //FAST FAIL VALIDATION
            Validate();
        }

        public void AlterarNome(string novoNome)
        {
            ValidateNome(novoNome);
            this.Nome = novoNome;
        }

        public void AdicionarProduto(ProdutoEntity produto)
        {
           Produtos.Add(produto);
            ValidateProdutos();
        }

        public void RemoverProduto(ProdutoEntity produto)
        {
            if (Produtos.Count() == 0)
                return;

            Produtos.Remove(produto);
        }
        public override bool Validate()
        {
            this.isValid = true;
            ValidateCPF();
            ValidateNome(this.Nome);
            ValidateProdutos();
            return base.Validate();
        }

        private void ValidateNome(string value)
        {

            if (value.Length > 160)
            {
                this.Notifications.Items
                     .Add(("Nome",
                           "Nome do cliente não pode ter mais do que 150 caracteres"));
                this.isValid = false;
            }

        }
        private void ValidateCPF()
        {
            if (!Cpf.isValid)
            {
                this.Notifications.Items
                    .Add(("CPF", "CPF do cliente é inválido."));
                this.isValid = false;
            }
        }
        private void ValidateProdutos()
        {
            if (Produtos.Count > 15)
            {
                this.Notifications.Items
                   .Add(("Produtos", "Cliente não deve conter mais de 15 produtos."));
                this.isValid = false;
            }
                         
        }
    }
}