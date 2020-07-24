namespace ClientesProdutos.Infrastructure.Persistence.Repositories
{
    public interface IDeletableRepository<T>
    {
        void Delete(T item);
    }
}