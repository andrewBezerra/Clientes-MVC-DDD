using System;

namespace ClientesProdutos.Shared.Entities
{
    public class AuditableEntity:CommonEntity
    {

        public AuditableEntity(string username)
        {
            CreatedBy = username;
            Created = DateTime.Now;
        }

        public virtual string CreatedBy { get; private set; }

        public virtual DateTime Created { get; private set; }

        public virtual string LastModifiedBy { get; private set; }

        public virtual DateTime? LastModified { get; private set; }
    }
}