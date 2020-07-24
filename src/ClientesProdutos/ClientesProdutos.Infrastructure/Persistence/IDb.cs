using NHibernate;
using System.Data;

namespace ClientesProdutos.Infrastructure.Persistence
{
    public interface IDb
    {
        IDbConnection Connection();
        ISession Session { get;  }
      
    }
}