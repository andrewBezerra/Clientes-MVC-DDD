using ClientesProdutos.Shared.Entities;

namespace ClientesProdutos.Domain.Entities
{
    public class ProdutoEntity : AuditableEntity
    {
        public virtual string Nome { get => _nome; }
        private string _nome;

        protected ProdutoEntity():base("teste")
        { }
        public ProdutoEntity(string nome,
                             string username
                            ) : base(username)
        {
            _nome = nome;
            Validate();
        }

        public override bool Validate()
        {
            this.isValid = true;
            ValidateNome(this.Nome);
            return base.Validate();
        }

        private void ValidateNome(string value)
        {
            if (value.Length > 150)
            {
                this.Notifications.Items
                     .Add(("Nome",
                           "Nome do produto não pode ter mais do que 150 caracteres"));
                this.isValid = false;
            }
        }

        public virtual void AlterarNome(string novoNome)
        {
            ValidateNome(novoNome);
            this._nome = novoNome;
        }
    }
}