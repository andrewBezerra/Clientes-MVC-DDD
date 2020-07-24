using System;
using System.Collections.Generic;

namespace ClientesProdutos.Infrastructure.Persistence.Repositories
{
    public interface ICommonRepository<T>
    {
      
        void Add(T item);

        void Update(T item);

        T GetbyID(Guid id);

        IEnumerable<T> ListAll();
    }
}