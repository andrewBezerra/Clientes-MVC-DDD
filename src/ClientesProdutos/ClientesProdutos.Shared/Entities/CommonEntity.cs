using System;

namespace ClientesProdutos.Shared.Entities
{
    public class CommonEntity
    {
        public Guid ID { get; private set; }

        public CommonEntity()
        {
            ID = Guid.NewGuid();
        }
    }
}