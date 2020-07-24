using ClientesProdutos.Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientesProdutos.Infrastructure.Persistence.Repositories
{
    public class ClienteRepository : ICommonRepository<ClienteEntity>
    {
        public ClienteRepository(IDb db)
        {
            Db = db;
        }

        private IDb Db { get; set; }

        public void Add(ClienteEntity item)
        {
            using (var session = Db.Session)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(item);
                    transaction.Commit();
                }
            }
        }

        public ClienteEntity GetbyID(Guid id)
        {
            using (var session = Db.Session)
            {
                return session.Get<ClienteEntity>(id);
            }
        }

        public ClienteEntity GetbyName(string Name)
        {
            using (var session = Db.Session)
            {
                return session.Query<ClienteEntity>().Where(x => x.Nome.ToUpper() == Name.ToUpper()).First();
            }
        }

        public IEnumerable<ClienteEntity> ListAll()
        {
            using (var session = Db.Session)
            {
                return session.Query<ClienteEntity>();
            }
        }

        public void Update(ClienteEntity item)
        {
            using (var session = Db.Session)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(item);
                    transaction.Commit();
                }
            }
        }
    }
}