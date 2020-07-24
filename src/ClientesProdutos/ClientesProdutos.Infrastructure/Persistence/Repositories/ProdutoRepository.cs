using ClientesProdutos.Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;

namespace ClientesProdutos.Infrastructure.Persistence.Repositories.Produto
{
    public class ProdutoRepository
            : ICommonRepository<ProdutoEntity>,
              IDeletableRepository<ProdutoEntity>
    {
        public ProdutoRepository(IDb db)
        {
            Db = db;
        }

        private IDb Db { get; set; }

        public void Add(ProdutoEntity item)
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

        public void Delete(ProdutoEntity item)
        {
            using (var session = Db.Session)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(item);
                    transaction.Commit();
                }
            }
        }

        public ProdutoEntity GetbyID(Guid id)
        {
            using (var session = Db.Session)
            {
                return session.Get<ProdutoEntity>(id);
            }
        }

        public IEnumerable<ProdutoEntity> ListAll()
        {
            using (var session = Db.Session)
            {
                return session.Query<ProdutoEntity>();
            }
        }

        public void Update(ProdutoEntity item)
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