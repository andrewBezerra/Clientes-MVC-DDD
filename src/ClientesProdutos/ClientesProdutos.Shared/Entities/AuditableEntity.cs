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

        public string CreatedBy { get; private set; }

        public DateTime Created { get; private set; }

        public string LastModifiedBy { get; private set; }

        public DateTime? LastModified { get; private set; }
    }
}