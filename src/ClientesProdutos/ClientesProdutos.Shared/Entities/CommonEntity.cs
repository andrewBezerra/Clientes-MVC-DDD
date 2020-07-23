using ClientesProdutos.Shared.Notifications;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClientesProdutos.Shared.Entities
{
    public class CommonEntity
    {
        public Guid ID { get; private set; }
        public DomainNotifications Notifications { get; private set; }
                                                                                                 
        public bool isValid { get; protected set; }

        public virtual bool Validate()
        {
            return this.isValid;
        }

        public CommonEntity()
        {
            ID = Guid.NewGuid();
            Notifications = new DomainNotifications();
        }
    }
}