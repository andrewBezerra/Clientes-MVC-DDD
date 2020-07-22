using System.Data;

namespace ClientesProdutos.Infrastructure.Persistence
{
    public interface IDb
    {
        IDbConnection Connection();
    }
}                                                