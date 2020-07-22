using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClientesProdutos.Infrastructure.Persistence
{
    public class SQLServerDb : IDb
    {
        IDbConnection IDb.Connection()
        {
            throw new NotImplementedException();
        }
    }
}
