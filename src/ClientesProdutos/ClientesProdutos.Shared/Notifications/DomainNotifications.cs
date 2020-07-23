using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ClientesProdutos.Shared.Notifications
{
    public class DomainNotifications
    {

        /// <summary>
        /// Item 1 - Propriedade ou Campo.
        /// Item 2 - Descritivo da Notificação.
        /// </summary>
        public IList<ValueTuple<string, string>> Items { get; private set; } = new List<ValueTuple<string, string>>();

        public DomainNotifications()
        {
            
        }

        public override string ToString()
        {
            var value = string.Empty;

            foreach (var notification in Items)
                value+= $"{notification.Item1} - \"{notification.Item2}\"";

            return value;
        }
    }
}